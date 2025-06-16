using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.DTOs.Request
{
    public class PlanlamaRequestDto
    {
        public int? SiparisId { get; set; }
        public bool TumSiparisleriPlanla { get; set; } = false;
    }

    public class GorevZamaniGuncellemeDto
    {
        [Required(ErrorMessage = "Üretim görevi ID zorunludur")]
        public int UretimGoreviId { get; set; }

        [Required(ErrorMessage = "Yeni başlangıç zamanı zorunludur")]
        public DateTime YeniBaslangicZamani { get; set; }
    }

    public class PersonelPlanSorguDto
    {
        [Required(ErrorMessage = "Personel ID zorunludur")]
        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur")]
        public DateTime BaslangicTarihi { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime BitisTarihi { get; set; }
    }
}
