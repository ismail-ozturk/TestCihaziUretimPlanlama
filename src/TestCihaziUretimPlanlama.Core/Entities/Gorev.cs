using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class Gorev : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(1000)]
        public string Aciklama { get; set; }

        [Required]
        public int DepartmanId { get; set; }

        [Required]
        public int Sure { get; set; } // Saat cinsinden

        public bool Aktif { get; set; } = true;

        // Navigation Properties
        public virtual Departman Departman { get; set; }
        public virtual ICollection<PersonelGorevYetkinlik> PersonelYetkinlikleri { get; set; } = new List<PersonelGorevYetkinlik>();
        public virtual ICollection<KategoriGorevSablonu> KategoriSablonlari { get; set; } = new List<KategoriGorevSablonu>();
        public virtual ICollection<UretimGorevi> UretimGorevleri { get; set; } = new List<UretimGorevi>();
    }
}
