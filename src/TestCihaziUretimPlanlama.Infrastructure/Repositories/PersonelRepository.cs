using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Repositories
{
    public class PersonelRepository : Repository<Personel>, IPersonelRepository
    {
        public PersonelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Personel> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Departman)
                .Include(p => p.GorevYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Gorev)
                .Include(p => p.Izinler.Where(i => !i.IsDeleted))
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public override async Task<IEnumerable<Personel>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Departman)
                .Include(p => p.GorevYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Gorev)
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Personel>> GetByDepartmanIdAsync(int departmanId)
        {
            return await _dbSet
                .Include(p => p.Departman)
                .Include(p => p.GorevYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Gorev)
                .Where(p => p.DepartmanId == departmanId && p.Aktif && !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Personel>> GetAktifPersonellerAsync()
        {
            return await _dbSet
                .Include(p => p.Departman)
                .Include(p => p.GorevYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Gorev)
                .Where(p => p.Aktif && !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<Personel> GetByPersonelNoAsync(string personelNo)
        {
            return await _dbSet
                .Include(p => p.Departman)
                .Include(p => p.GorevYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Gorev)
                .FirstOrDefaultAsync(p => p.PersonelNo == personelNo && !p.IsDeleted);
        }

        public async Task<IEnumerable<Personel>> GetYetkinPersonellerAsync(int gorevId)
        {
            return await _dbSet
                .Include(p => p.Departman)
                .Include(p => p.GorevYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Gorev)
                .Where(p => p.Aktif && !p.IsDeleted && p.GorevYetkinlikleri.Any(y => y.GorevId == gorevId && !y.IsDeleted))
                .ToListAsync();
        }

        public async Task<IEnumerable<Personel>> GetMusaitPersonellerAsync(DateTime baslangic, DateTime bitis)
        {
            return await _dbSet
                .Include(p => p.Departman)
                .Include(p => p.Izinler.Where(i => !i.IsDeleted))
                .Include(p => p.AtanmisGorevler.Where(g => !g.IsDeleted))
                .Where(p => p.Aktif && !p.IsDeleted)
                .Where(p => !p.Izinler.Any(i =>
                    i.BaslangicTarihi <= bitis && i.BitisTarihi >= baslangic && !i.IsDeleted))
                .Where(p => !p.AtanmisGorevler.Any(g =>
                    g.PlanlananBaslangic <= bitis && g.PlanlananBitis >= baslangic && !g.IsDeleted))
                .ToListAsync();
        }

        public async Task<bool> PersonelNoMevcutMuAsync(string personelNo, int? excludeId = null)
        {
            var query = _dbSet.Where(p => p.PersonelNo == personelNo && !p.IsDeleted);

            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }
    }
}
