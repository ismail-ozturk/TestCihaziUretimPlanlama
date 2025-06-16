using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class KategoriGorevBagimlilik : BaseEntity
    {
        public int OncuKategoriGorevSablonuId { get; set; }
        public int ArdilKategoriGorevSablonuId { get; set; }
        public BagimlilikTipi BagimlilikTipi { get; set; } = BagimlilikTipi.FinishToStart;
        public int GecikmeGunu { get; set; } = 0;

        // Navigation Properties
        public virtual KategoriGorevSablonu OncuGorev { get; set; }
        public virtual KategoriGorevSablonu ArdilGorev { get; set; }
    }
}
