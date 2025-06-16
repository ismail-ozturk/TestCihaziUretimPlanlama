namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class PlanlamaResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int PlanlananSiparisSayisi { get; set; }
        public int PlanlananGorevSayisi { get; set; }
        public DateTime PlanlamaTarihi { get; set; }
        public List<string> Uyarilar { get; set; } = new List<string>();
        public List<string> Hatalar { get; set; } = new List<string>();
    }

    public class PersonelPlanDto
    {
        public int PersonelId { get; set; }
        public string PersonelAdi { get; set; }
        public string DepartmanAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public double IsYukuYuzdesi { get; set; }
        public List<UretimGoreviDto> Gorevler { get; set; } = new List<UretimGoreviDto>();
    }
}
