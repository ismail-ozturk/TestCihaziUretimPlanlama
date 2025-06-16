using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.DTOs.Request
{
    public class KategoriCreateDto
    {
        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir")]
        public string Ad { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Aciklama { get; set; }

        public bool Aktif { get; set; } = true;

        public List<KategoriGorevSablonuCreateDto> GorevSablonlari { get; set; } = new List<KategoriGorevSablonuCreateDto>();
    }

    public class KategoriUpdateDto : KategoriCreateDto
    {
        public int Id { get; set; }
    }

    public class KategoriGorevSablonuCreateDto
    {
        [Required(ErrorMessage = "Görev seçimi zorunludur")]
        public int GorevId { get; set; }

        [Required(ErrorMessage = "Sıra numarası zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Sıra numarası 1'den büyük olmalıdır")]
        public int Sira { get; set; }

        public int? OzelSure { get; set; }

        public List<int> OncuGorevSablonIds { get; set; } = new List<int>();
    }

    public class KategoriGorevBagimlilikCreateDto
    {
        [Required]
        public int OncuKategoriGorevSablonuId { get; set; }

        [Required]
        public int ArdilKategoriGorevSablonuId { get; set; }

        public Core.Enums.BagimlilikTipi BagimlilikTipi { get; set; } = Core.Enums.BagimlilikTipi.FinishToStart;

        public int GecikmeGunu { get; set; } = 0;
    }
}
