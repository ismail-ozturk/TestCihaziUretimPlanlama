using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Services
{
    public interface IGorevService
    {
        Task<IEnumerable<UretimGorevi>> SablondanUretimGorevleriOlusturAsync(int siparisId, int kategoriId);
        Task<IEnumerable<UretimGorevi>> ManuelUretimGorevleriOlusturAsync(int siparisId, List<GorevCreateModel> gorevler);
        Task<bool> GorevBagimlilikKontrolAsync(int oncuGorevId, int ardilGorevId);
        Task<IEnumerable<UretimGorevi>> KritikYoluHesaplaAsync(int siparisId);
    }

    public class GorevCreateModel
    {
        public int GorevId { get; set; }
        public int? OzelSure { get; set; }
        public string OzelAciklama { get; set; }
        public List<int> OncuGorevIds { get; set; } = new List<int>();
    }
}
