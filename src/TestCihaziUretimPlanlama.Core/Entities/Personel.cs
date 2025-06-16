using System.ComponentModel.DataAnnotations;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class Personel : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [Required]
        [StringLength(100)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonelNo { get; set; }

        [Required]
        public int DepartmanId { get; set; }

        public CalismaSekli CalismaSekli { get; set; }

        // Sabit çalışma için
        public VardiyaTipi? SabitVardiyaTipi { get; set; }

        // Döner çalışma için
        public VardiyaTipi? DonerVardiyaBaslangicTipi { get; set; }
        public DateTime? DonerVardiyaBaslangicTarihi { get; set; }

        public bool Aktif { get; set; } = true;

        // Navigation Properties
        public virtual Departman Departman { get; set; }
        public virtual ICollection<PersonelGorevYetkinlik> GorevYetkinlikleri { get; set; } = new List<PersonelGorevYetkinlik>();
        public virtual ICollection<PersonelIzin> Izinler { get; set; } = new List<PersonelIzin>();
        public virtual ICollection<UretimGorevi> AtanmisGorevler { get; set; } = new List<UretimGorevi>();
    }
}
