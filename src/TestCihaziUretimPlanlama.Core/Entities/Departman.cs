using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class Departman : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public bool Aktif { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Personel> Personeller { get; set; } = new List<Personel>();
        public virtual ICollection<Gorev> Gorevler { get; set; } = new List<Gorev>();
    }
}
