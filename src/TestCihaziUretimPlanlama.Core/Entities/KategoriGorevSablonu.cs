namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class KategoriGorevSablonu : BaseEntity
    {
        public int KategoriId { get; set; }
        public int GorevId { get; set; }
        public int Sira { get; set; }
        public int? OzelSure { get; set; } // Kategoriye özel süre (opsiyonel)

        // Navigation Properties
        public virtual Kategori Kategori { get; set; }
        public virtual Gorev Gorev { get; set; }
        public virtual ICollection<KategoriGorevBagimlilik> OncuBagimliliklar { get; set; } = new List<KategoriGorevBagimlilik>();
        public virtual ICollection<KategoriGorevBagimlilik> ArdilBagimliliklar { get; set; } = new List<KategoriGorevBagimlilik>();
    }
}
