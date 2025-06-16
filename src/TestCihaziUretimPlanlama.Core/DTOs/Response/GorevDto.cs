namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class GorevDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
        public int Sure { get; set; }
        public bool Aktif { get; set; }
        public DateTime CreatedDate { get; set; }
        public int YetkinPersonelSayisi { get; set; }
    }

    public class GorevDetayDto : GorevDto
    {
        public List<PersonelDto> YetkinPersoneller { get; set; } = new List<PersonelDto>();
    }
}
