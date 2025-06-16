using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Repositories
{
    public class KategoriRepository : Repository<Kategori>, IKategoriRepository
    {
        // DbContext'e erişim için public property ekleyin
        public ApplicationDbContext Context => _context;

        public KategoriRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Kategori> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(k => k.GorevSablonlari.Where(s => !s.IsDeleted))
                    .ThenInclude(s => s.Gorev)
                        .ThenInclude(g => g.Departman)
                .FirstOrDefaultAsync(k => k.Id == id && !k.IsDeleted);
        }

        public override async Task<IEnumerable<Kategori>> GetAllAsync()
        {
            return await _dbSet
                .Include(k => k.GorevSablonlari.Where(s => !s.IsDeleted))
                .Where(k => !k.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Kategori>> GetAktifKategorilerAsync()
        {
            return await _dbSet
                .Include(k => k.GorevSablonlari.Where(s => !s.IsDeleted))
                .Where(k => k.Aktif && !k.IsDeleted)
                .ToListAsync();
        }

        public async Task<Kategori> GetDetayliKategoriAsync(int id)
        {
            return await _dbSet
                .Include(k => k.GorevSablonlari.Where(s => !s.IsDeleted))
                    .ThenInclude(s => s.Gorev)
                        .ThenInclude(g => g.Departman)
                .FirstOrDefaultAsync(k => k.Id == id && !k.IsDeleted);
        }

        public async Task<Kategori> GetByAdAsync(string ad)
        {
            return await _dbSet
                .FirstOrDefaultAsync(k => k.Ad == ad && !k.IsDeleted);
        }

        public async Task<bool> AdMevcutMuAsync(string ad, int? excludeId = null)
        {
            var query = _dbSet.Where(k => k.Ad == ad && !k.IsDeleted);

            if (excludeId.HasValue)
            {
                query = query.Where(k => k.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<KategoriGorevSablonu>> GetGorevSablonlariAsync(int kategoriId)
        {
            return await _context.KategoriGorevSablonlari
                .Include(s => s.Gorev)
                    .ThenInclude(g => g.Departman)
                .Where(s => s.KategoriId == kategoriId && !s.IsDeleted)
                .OrderBy(s => s.Sira)
                .ToListAsync();
        }

        public async Task<IEnumerable<KategoriGorevBagimlilik>> GetBagimliliklarAsync(int kategoriId)
        {
            // Önce kategori şablonlarının ID'lerini al
            var sablonIds = await _context.KategoriGorevSablonlari
                .Where(s => s.KategoriId == kategoriId && !s.IsDeleted)
                .Select(s => s.Id)
                .ToListAsync();

            if (!sablonIds.Any())
                return new List<KategoriGorevBagimlilik>();

            // Sonra bağımlılıkları getir
            return await _context.KategoriGorevBagimliliklari
                .Where(b => !b.IsDeleted &&
                           (sablonIds.Contains(b.OncuKategoriGorevSablonuId) ||
                            sablonIds.Contains(b.ArdilKategoriGorevSablonuId)))
                .Select(b => new KategoriGorevBagimlilik
                {
                    Id = b.Id,
                    OncuKategoriGorevSablonuId = b.OncuKategoriGorevSablonuId,
                    ArdilKategoriGorevSablonuId = b.ArdilKategoriGorevSablonuId,
                    BagimlilikTipi = b.BagimlilikTipi,
                    GecikmeGunu = b.GecikmeGunu,
                    CreatedDate = b.CreatedDate
                })
                .ToListAsync();
        }

    }
}
