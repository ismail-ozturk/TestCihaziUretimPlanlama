using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Repositories
{
    public class SiparisRepository : Repository<Siparis>, ISiparisRepository
    {
        public SiparisRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Siparis>> GetByDurumAsync(SiparisDurum durum)
        {
            return await _dbSet
                .Include(s => s.Kategori)
                .Where(s => s.Durum == durum)
                .OrderBy(s => s.Oncelik)
                .ThenBy(s => s.IstenilenBaslangicTarihi)
                .ToListAsync();
        }

        public async Task<Siparis> GetDetayliSiparisAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Kategori)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.Gorev)
                        .ThenInclude(g => g.Departman)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.AtananPersonel)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Siparis> GetByUretimNumarasiAsync(string uretimNumarasi)
        {
            return await _dbSet
                .Include(s => s.Kategori)
                .FirstOrDefaultAsync(s => s.UretimNumarasi == uretimNumarasi);
        }

        public async Task<IEnumerable<Siparis>> GetPlanlanacakSiparislerAsync()
        {
            return await _dbSet
                .Include(s => s.Kategori)
                .Include(s => s.UretimGorevleri)
                .Where(s => s.Durum == SiparisDurum.Beklemede)
                .OrderBy(s => s.Oncelik)
                .ThenBy(s => s.IstenilenBaslangicTarihi)
                .ToListAsync();
        }

        public async Task<bool> UretimNumarasiMevcutMuAsync(string uretimNumarasi, int? excludeId = null)
        {
            var query = _dbSet.Where(s => s.UretimNumarasi == uretimNumarasi);

            if (excludeId.HasValue)
            {
                query = query.Where(s => s.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }
    }
}
