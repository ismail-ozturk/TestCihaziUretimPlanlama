using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class UretimGoreviDto
    {
        public int Id { get; set; }
        public int SiparisId { get; set; }
        public string SiparisUretimNumarasi { get; set; }
        public int GorevId { get; set; }
        public string GorevAdi { get; set; }
        public string GorevAciklama { get; set; }
        public string DepartmanAdi { get; set; }
        public int? AtananPersonelId { get; set; }
        public string AtananPersonelAdi { get; set; }
        public int Sure { get; set; }
        public DateTime? PlanlananBaslangic { get; set; }
        public DateTime? PlanlananBitis { get; set; }
        public DateTime? GercekBaslangic { get; set; }
        public DateTime? GercekBitis { get; set; }
        public GorevDurum Durum { get; set; }
        public string DurumText => Durum.ToString();
        public string Notlar { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<UretimGorevBagimlilikDto> OncuBagimliliklar { get; set; } = new List<UretimGorevBagimlilikDto>();
        public List<UretimGorevBagimlilikDto> ArdilBagimliliklar { get; set; } = new List<UretimGorevBagimlilikDto>();
    }

    public class UretimGorevBagimlilikDto
    {
        public int Id { get; set; }
        public int OncuGorevId { get; set; }
        public string OncuGorevAdi { get; set; }
        public int ArdilGorevId { get; set; }
        public string ArdilGorevAdi { get; set; }
        public BagimlilikTipi BagimlilikTipi { get; set; }
        public int GecikmeGunu { get; set; }
    }
}
