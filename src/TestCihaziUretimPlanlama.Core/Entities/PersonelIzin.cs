using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class PersonelIzin : BaseEntity
    {
        public int PersonelId { get; set; }

        [Required]
        public DateTime BaslangicTarihi { get; set; }

        [Required]
        public DateTime BitisTarihi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        // Navigation Properties
        public virtual Personel Personel { get; set; }
    }
}
