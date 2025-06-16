namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class PersonelGorevYetkinlik : BaseEntity
    {
        public int PersonelId { get; set; }
        public int GorevId { get; set; }

        // Navigation Properties
        public virtual Personel Personel { get; set; }
        public virtual Gorev Gorev { get; set; }
    }
}
