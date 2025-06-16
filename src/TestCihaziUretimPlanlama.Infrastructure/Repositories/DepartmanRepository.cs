using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Repositories
{
    public class DepartmanRepository : Repository<Departman>, IDepartmanRepository
    {
        public DepartmanRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Departman> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(d => d.Personeller.Where(p => !p.IsDeleted))
                .Include(d => d.Gorevler.Where(g => !g.IsDeleted))
                .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        }

        public override async Task<IEnumerable<Departman>> GetAllAsync()
        {
            return await _dbSet
                .Include(d => d.Personeller.Where(p => !p.IsDeleted))
                .Include(d => d.Gorevler.Where(g => !g.IsDeleted))
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Departman>> GetAktifDepartmanlarAsync()
        {
            return await _dbSet
                .Include(d => d.Personeller.Where(p => !p.IsDeleted && p.Aktif))
                .Include(d => d.Gorevler.Where(g => !g.IsDeleted && g.Aktif))
                .Where(d => d.Aktif && !d.IsDeleted)
                .ToListAsync();
        }

        public async Task<Departman> GetByAdAsync(string ad)
        {
            return await _dbSet
                .Include(d => d.Personeller)
                .Include(d => d.Gorevler)
                .FirstOrDefaultAsync(d => d.Ad == ad && !d.IsDeleted);
        }

        public async Task<bool> AdMevcutMuAsync(string ad, int? excludeId = null)
        {
            var query = _dbSet.Where(d => d.Ad == ad && !d.IsDeleted);

            if (excludeId.HasValue)
            {
                query = query.Where(d => d.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }
    }
}
