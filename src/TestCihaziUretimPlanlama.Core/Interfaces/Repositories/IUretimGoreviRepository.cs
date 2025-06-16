using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Repositories
{
    public interface IUretimGoreviRepository : IRepository<UretimGorevi>
    {
        Task<IEnumerable<UretimGorevi>> GetBySiparisIdAsync(int siparisId);
        Task<IEnumerable<UretimGorevi>> GetByPersonelIdAsync(int personelId);
        Task<IEnumerable<UretimGorevi>> GetByDurumAsync(GorevDurum durum);
        Task<IEnumerable<UretimGorevi>> GetPersonelGorevleriAsync(int personelId, DateTime baslangic, DateTime bitis);
        Task<IEnumerable<UretimGorevi>> GetDetayliUretimGorevleriAsync(int siparisId);
        Task<IEnumerable<UretimGorevi>> GetAktifGorevlerAsync();
    }
}
