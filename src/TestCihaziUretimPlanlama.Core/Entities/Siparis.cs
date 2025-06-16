using System.ComponentModel.DataAnnotations;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class Siparis : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string UretimNumarasi { get; set; }

        public Musteri Musteri { get; set; }

        [Required]
        public DateTime IstenilenBaslangicTarihi { get; set; }

        public int? KategoriId { get; set; }

        public bool KategoriSablonuKullan { get; set; } = false;

        public SiparisDurum Durum { get; set; } = SiparisDurum.Beklemede;

        public int Oncelik { get; set; } = 5; // 1-10 arası

        public DateTime? SonTeslimTarihi { get; set; }

        [StringLength(1000)]
        public string Notlar { get; set; }

        public int? ZorunluPmdPersonelId { get; set; }
        public int? ZorunluCncPersonelId { get; set; }
        public int? ZorunluTeknikPersonelId { get; set; }

        // Navigation Properties
        public virtual Kategori Kategori { get; set; }


        public virtual ICollection<UretimGorevi> UretimGorevleri { get; set; } = new List<UretimGorevi>();
        public virtual Personel ZorunluPmdPersonel { get; set; }
        public virtual Personel ZorunluCncPersonel { get; set; }
        public virtual Personel ZorunluTeknikPersonel { get; set; }
    }
}
