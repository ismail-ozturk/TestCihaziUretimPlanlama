using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class UretimGorevBagimlilik : BaseEntity
    {
        public int OncuUretimGoreviId { get; set; }
        public int ArdilUretimGoreviId { get; set; }
        public BagimlilikTipi BagimlilikTipi { get; set; } = BagimlilikTipi.FinishToStart;
        public int GecikmeGunu { get; set; } = 0;

        // Navigation Properties
        public virtual UretimGorevi OncuGorev { get; set; }
        public virtual UretimGorevi ArdilGorev { get; set; }
    }
}
