using System.ComponentModel.DataAnnotations;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.DTOs.Request
{
    public class SiparisCreateDto
    {
        [Required(ErrorMessage = "Üretim numarası zorunludur")]
        [StringLength(50, ErrorMessage = "Üretim numarası en fazla 50 karakter olabilir")]
        public string UretimNumarasi { get; set; }

        [Required(ErrorMessage = "Müşteri seçimi zorunludur")]
        public Musteri Musteri { get; set; }

        [Required(ErrorMessage = "İstenilen başlangıç tarihi zorunludur")]
        public DateTime IstenilenBaslangicTarihi { get; set; }

        public int? KategoriId { get; set; }

        public bool KategoriSablonuKullan { get; set; } = false;

        [Range(1, 10, ErrorMessage = "Öncelik 1-10 arasında olmalıdır")]
        public int Oncelik { get; set; } = 5;

        public DateTime? SonTeslimTarihi { get; set; }

        [StringLength(1000, ErrorMessage = "Notlar en fazla 1000 karakter olabilir")]
        public string Notlar { get; set; }
        public int? ZorunluPmdPersonelId { get; set; }
        public int? ZorunluCncPersonelId { get; set; }
        public int? ZorunluTeknikPersonelId { get; set; }

        public List<SiparisGorevCreateDto> Gorevler { get; set; } = new List<SiparisGorevCreateDto>();
    }

    public class SiparisGorevCreateDto
    {
        [Required(ErrorMessage = "Görev seçimi zorunludur")]
        public int GorevId { get; set; }

        public int? OzelSure { get; set; }

        [StringLength(1000, ErrorMessage = "Özel açıklama en fazla 1000 karakter olabilir")]
        public string? OzelAciklama { get; set; }

        public List<int> OncuGorevIds { get; set; } = new List<int>();
    }
}
