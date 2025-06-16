using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Services
{
    public interface ISiparisService
    {
        Task<Siparis> SiparisOlusturAsync(SiparisCreateModel model);
        Task<bool> SiparisDurumGuncelleAsync(int siparisId, SiparisDurum yeniDurum);
        Task<IEnumerable<Siparis>> GetPlanlanacakSiparislerAsync();
        Task<Siparis> GetDetayliSiparisAsync(int id);
        Task<bool> SiparisIptalAsync(int siparisId);
    }

    public class SiparisCreateModel
    {
        public string UretimNumarasi { get; set; }
        public Musteri Musteri { get; set; }
        public DateTime IstenilenBaslangicTarihi { get; set; }
        public int? KategoriId { get; set; }
        public bool KategoriSablonuKullan { get; set; }
        public int Oncelik { get; set; } = 5;
        public DateTime? SonTeslimTarihi { get; set; }
        public string Notlar { get; set; }
        public int? ZorunluPmdPersonelId { get; set; }
        public int? ZorunluCncPersonelId { get; set; }
        public int? ZorunluTeknikPersonelId { get; set; }

        public List<GorevCreateModel> Gorevler { get; set; } = new List<GorevCreateModel>();
    }
}
