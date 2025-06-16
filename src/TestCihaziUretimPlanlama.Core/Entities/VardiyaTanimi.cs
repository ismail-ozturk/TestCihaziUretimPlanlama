using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Entities
{
    public class VardiyaTanimi : BaseEntity
    {
        public VardiyaTipi VardiyaTipi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public bool CumartesiCalismasi { get; set; } = false;
        public bool Aktif { get; set; } = true;
    }
}
