using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Repositories
{
    public interface IPersonelRepository : IRepository<Personel>
    {
        Task<IEnumerable<Personel>> GetByDepartmanIdAsync(int departmanId);
        Task<IEnumerable<Personel>> GetAktifPersonellerAsync();
        Task<Personel> GetByPersonelNoAsync(string personelNo);
        Task<IEnumerable<Personel>> GetYetkinPersonellerAsync(int gorevId);
        Task<IEnumerable<Personel>> GetMusaitPersonellerAsync(DateTime baslangic, DateTime bitis);
        Task<bool> PersonelNoMevcutMuAsync(string personelNo, int? excludeId = null);
    }
}
