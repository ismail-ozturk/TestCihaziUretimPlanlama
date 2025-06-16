using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class PlanDisiTarih : BaseEntity
    {
        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(200)]
        public string Aciklama { get; set; }

        public bool TekrarliMi { get; set; } = false; // Yıllık tekrar eden tatiller için
    }
}
