using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Repositories
{
    public class UretimGoreviRepository : Repository<UretimGorevi>, IUretimGoreviRepository
    {
        public UretimGoreviRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UretimGorevi>> GetBySiparisIdAsync(int siparisId)
        {
            return await _dbSet
                .Include(ug => ug.Gorev)
                    .ThenInclude(g => g.Departman)
                .Include(ug => ug.AtananPersonel)
                .Where(ug => ug.SiparisId == siparisId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UretimGorevi>> GetByPersonelIdAsync(int personelId)
        {
            return await _dbSet
                .Include(ug => ug.Siparis)
                .Include(ug => ug.Gorev)
                    .ThenInclude(g => g.Departman)
                .Where(ug => ug.AtananPersonelId == personelId)
                .OrderBy(ug => ug.PlanlananBaslangic)
                .ToListAsync();
        }

        public async Task<IEnumerable<UretimGorevi>> GetByDurumAsync(GorevDurum durum)
        {
            return await _dbSet
                .Include(ug => ug.Siparis)
                .Include(ug => ug.Gorev)
                .Include(ug => ug.AtananPersonel)
                .Where(ug => ug.Durum == durum)
                .ToListAsync();
        }

        public async Task<IEnumerable<UretimGorevi>> GetPersonelGorevleriAsync(int personelId, DateTime baslangic, DateTime bitis)
        {
            return await _dbSet
                .Include(ug => ug.Siparis)
                .Include(ug => ug.Gorev)
                .Where(ug => ug.AtananPersonelId == personelId)
                .Where(ug => ug.PlanlananBaslangic <= bitis && ug.PlanlananBitis >= baslangic)
                .OrderBy(ug => ug.PlanlananBaslangic)
                .ToListAsync();
        }

        public async Task<IEnumerable<UretimGorevi>> GetDetayliUretimGorevleriAsync(int siparisId)
        {
            return await _dbSet
                .Include(ug => ug.Gorev)
                    .ThenInclude(g => g.Departman)
                .Include(ug => ug.AtananPersonel)
                .Include(ug => ug.OncuBagimliliklar)
                    .ThenInclude(b => b.OncuGorev)
                .Include(ug => ug.ArdilBagimliliklar)
                    .ThenInclude(b => b.ArdilGorev)
                .Where(ug => ug.SiparisId == siparisId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UretimGorevi>> GetAktifGorevlerAsync()
        {
            return await _dbSet
                .Include(ug => ug.Siparis)
                .Include(ug => ug.Gorev)
                .Include(ug => ug.AtananPersonel)
                .Where(ug => ug.Durum == GorevDurum.DevamEdiyor || ug.Durum == GorevDurum.Planli)
                .OrderBy(ug => ug.PlanlananBaslangic)
                .ToListAsync();
        }
    }
}
