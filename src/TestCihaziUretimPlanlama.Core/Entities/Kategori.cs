using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class Kategori : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public bool Aktif { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<KategoriGorevSablonu> GorevSablonlari { get; set; } = new List<KategoriGorevSablonu>();
        public virtual ICollection<Siparis> Siparisler { get; set; } = new List<Siparis>();
    }
}
