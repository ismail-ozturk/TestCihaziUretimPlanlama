using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Repositories
{
    public interface IDepartmanRepository : IRepository<Departman>
    {
        Task<IEnumerable<Departman>> GetAktifDepartmanlarAsync();
        Task<Departman> GetByAdAsync(string ad);
        Task<bool> AdMevcutMuAsync(string ad, int? excludeId = null);
    }
}
