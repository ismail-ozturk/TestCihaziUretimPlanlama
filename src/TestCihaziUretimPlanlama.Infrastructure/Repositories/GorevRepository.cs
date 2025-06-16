using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Repositories
{
    public class GorevRepository : Repository<Gorev>, IGorevRepository
    {
        public GorevRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Gorev> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(g => g.Departman)
                .Include(g => g.PersonelYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Personel)
                .FirstOrDefaultAsync(g => g.Id == id && !g.IsDeleted);
        }

        public override async Task<IEnumerable<Gorev>> GetAllAsync()
        {
            return await _dbSet
                .Include(g => g.Departman)
                .Include(g => g.PersonelYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Personel)
                .Where(g => !g.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gorev>> GetByDepartmanIdAsync(int departmanId)
        {
            return await _dbSet
                .Include(g => g.Departman)
                .Include(g => g.PersonelYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Personel)
                .Where(g => g.DepartmanId == departmanId && g.Aktif && !g.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gorev>> GetAktifGorevlerAsync()
        {
            return await _dbSet
                .Include(g => g.Departman)
                .Include(g => g.PersonelYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Personel)
                .Where(g => g.Aktif && !g.IsDeleted)
                .ToListAsync();
        }

        public async Task<Gorev> GetDetayliGorevAsync(int id)
        {
            return await _dbSet
                .Include(g => g.Departman)
                .Include(g => g.PersonelYetkinlikleri.Where(y => !y.IsDeleted))
                    .ThenInclude(y => y.Personel)
                .Include(g => g.KategoriSablonlari.Where(k => !k.IsDeleted))
                .FirstOrDefaultAsync(g => g.Id == id && !g.IsDeleted);
        }
    }
}
