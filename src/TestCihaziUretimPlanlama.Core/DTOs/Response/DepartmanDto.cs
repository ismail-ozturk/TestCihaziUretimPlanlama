namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class DepartmanDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Aktif { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int PersonelSayisi { get; set; }
        public int GorevSayisi { get; set; }
    }

    public class DepartmanDetayDto : DepartmanDto
    {
        public List<PersonelDto> Personeller { get; set; } = new List<PersonelDto>();
        public List<GorevDto> Gorevler { get; set; } = new List<GorevDto>();
    }
}
