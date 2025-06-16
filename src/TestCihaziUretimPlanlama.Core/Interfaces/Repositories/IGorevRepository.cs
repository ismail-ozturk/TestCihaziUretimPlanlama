using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Repositories
{
    public interface IGorevRepository : IRepository<Gorev>
    {
        Task<IEnumerable<Gorev>> GetByDepartmanIdAsync(int departmanId);
        Task<IEnumerable<Gorev>> GetAktifGorevlerAsync();
        Task<Gorev> GetDetayliGorevAsync(int id);
    }
}
