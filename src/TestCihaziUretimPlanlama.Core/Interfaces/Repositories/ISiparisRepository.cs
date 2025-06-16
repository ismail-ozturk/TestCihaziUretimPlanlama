using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Repositories
{
    public interface ISiparisRepository : IRepository<Siparis>
    {
        Task<IEnumerable<Siparis>> GetByDurumAsync(SiparisDurum durum);
        Task<Siparis> GetDetayliSiparisAsync(int id);
        Task<Siparis> GetByUretimNumarasiAsync(string uretimNumarasi);
        Task<IEnumerable<Siparis>> GetPlanlanacakSiparislerAsync();
        Task<bool> UretimNumarasiMevcutMuAsync(string uretimNumarasi, int? excludeId = null);
    }
}
