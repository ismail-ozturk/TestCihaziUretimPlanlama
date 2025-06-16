using System.ComponentModel.DataAnnotations;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class UretimGorevi : BaseEntity
    {
        public int SiparisId { get; set; }
        public int GorevId { get; set; }
        public int? AtananPersonelId { get; set; }

        public int Sure { get; set; } // Gerçek süre (şablondan veya manuel)

        // Planlama öncesi -> null, Planlama sonrası -> dolu
        public DateTime? PlanlananBaslangic { get; set; }
        public DateTime? PlanlananBitis { get; set; }

        // Üretim sırasında güncellenir
        public DateTime? GercekBaslangic { get; set; }
        public DateTime? GercekBitis { get; set; }

        public GorevDurum Durum { get; set; } = GorevDurum.Beklemede;

        [StringLength(1000)]
        public string Notlar { get; set; } = string.Empty; // Default değer

        // Navigation Properties
        public virtual Siparis Siparis { get; set; }
        public virtual Gorev Gorev { get; set; }
        public virtual Personel AtananPersonel { get; set; }
        public virtual ICollection<UretimGorevBagimlilik> OncuBagimliliklar { get; set; } = new List<UretimGorevBagimlilik>();
        public virtual ICollection<UretimGorevBagimlilik> ArdilBagimliliklar { get; set; } = new List<UretimGorevBagimlilik>();
    }
}
