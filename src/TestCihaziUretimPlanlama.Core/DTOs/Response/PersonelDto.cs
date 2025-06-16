using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class PersonelDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdSoyad => $"{Ad} {Soyad}";
        public string PersonelNo { get; set; }
        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
        public CalismaSekli CalismaSekli { get; set; }
        public string CalismaSekliText => CalismaSekli.ToString();
        public VardiyaTipi? SabitVardiyaTipi { get; set; }
        public VardiyaTipi? DonerVardiyaBaslangicTipi { get; set; }
        public DateTime? DonerVardiyaBaslangicTarihi { get; set; }
        public bool Aktif { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<GorevYetkinlikDto> GorevYetkinlikleri { get; set; } = new List<GorevYetkinlikDto>();
    }

    public class GorevYetkinlikDto
    {
        public int GorevId { get; set; }
        public string GorevAdi { get; set; }
    }
}
