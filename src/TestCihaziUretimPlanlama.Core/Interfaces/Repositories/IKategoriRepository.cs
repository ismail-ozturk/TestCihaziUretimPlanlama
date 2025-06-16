using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Repositories
{
    public interface IKategoriRepository : IRepository<Kategori>
    {
        Task<IEnumerable<Kategori>> GetAktifKategorilerAsync();
        Task<Kategori> GetDetayliKategoriAsync(int id);
        Task<Kategori> GetByAdAsync(string ad);
        Task<bool> AdMevcutMuAsync(string ad, int? excludeId = null);
        Task<IEnumerable<KategoriGorevSablonu>> GetGorevSablonlariAsync(int kategoriId);
        Task<IEnumerable<KategoriGorevBagimlilik>> GetBagimliliklarAsync(int kategoriId);
    }
}
