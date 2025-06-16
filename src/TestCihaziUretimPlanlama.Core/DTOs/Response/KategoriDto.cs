using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class KategoriDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Aktif { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int GorevSablonSayisi { get; set; }
        public int ToplamSure { get; set; }
    }

    public class KategoriDetayDto : KategoriDto
    {
        public List<KategoriGorevSablonuDto> GorevSablonlari { get; set; } = new List<KategoriGorevSablonuDto>();
        public List<KategoriGorevBagimlilikDto> Bagimliliklar { get; set; } = new List<KategoriGorevBagimlilikDto>();
    }

    public class KategoriGorevSablonuDto
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int GorevId { get; set; }
        public string GorevAdi { get; set; }
        public string GorevAciklama { get; set; }
        public string DepartmanAdi { get; set; }
        public int Sira { get; set; }
        public int? OzelSure { get; set; }
        public int VarsayilanSure { get; set; }
        public int GercekSure => OzelSure ?? VarsayilanSure;
        public DateTime CreatedDate { get; set; }
    }

    public class KategoriGorevBagimlilikDto
    {
        public int Id { get; set; }
        public int OncuKategoriGorevSablonuId { get; set; }
        public string OncuGorevAdi { get; set; }
        public int OncuGorevSira { get; set; }
        public int ArdilKategoriGorevSablonuId { get; set; }
        public string ArdilGorevAdi { get; set; }
        public int ArdilGorevSira { get; set; }
        public BagimlilikTipi BagimlilikTipi { get; set; }
        public string BagimlilikTipiText => BagimlilikTipi.ToString();
        public int GecikmeGunu { get; set; }
    }
}
