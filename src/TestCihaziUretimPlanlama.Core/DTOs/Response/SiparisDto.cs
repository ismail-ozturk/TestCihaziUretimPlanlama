using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class SiparisDto
    {
        public int Id { get; set; }
        public string UretimNumarasi { get; set; }
        public Musteri Musteri { get; set; }
        public string MusteriText => Musteri.ToString();
        public DateTime IstenilenBaslangicTarihi { get; set; }
        public int? KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public bool KategoriSablonuKullan { get; set; }
        public SiparisDurum Durum { get; set; }
        public string DurumText => Durum.ToString();
        public int Oncelik { get; set; }
        public DateTime? SonTeslimTarihi { get; set; }
        public string Notlar { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ToplamGorevSayisi { get; set; }
        public int TamamlananGorevSayisi { get; set; }
        public double TamamlanmaYuzdesi => ToplamGorevSayisi > 0 ? (double)TamamlananGorevSayisi / ToplamGorevSayisi * 100 : 0;
    }

    public class SiparisDetayDto : SiparisDto
    {
        public List<UretimGoreviDto> UretimGorevleri { get; set; } = new List<UretimGoreviDto>();
    }
}
