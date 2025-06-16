using System.ComponentModel.DataAnnotations;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.DTOs.Request
{
    public class GorevCreateDto
    {
        [Required(ErrorMessage = "Görev adı zorunludur")]
        [StringLength(100, ErrorMessage = "Görev adı en fazla 100 karakter olabilir")]
        public string Ad { get; set; }

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Departman seçimi zorunludur")]
        public int DepartmanId { get; set; }

        [Required(ErrorMessage = "Süre zorunludur")]
        [Range(1, int.MaxValue, ErrorMessage = "Süre 1 saatten az olamaz")]
        public int Sure { get; set; }

        public bool Aktif { get; set; } = true;
    }

    public class GorevUpdateDto : GorevCreateDto
    {
        public int Id { get; set; }
    }
    public class GorevDurumGuncellemeDto
    {
        [Required]
        public int GorevId { get; set; }

        [Required]
        public GorevDurum YeniDurum { get; set; }

        public string? Aciklama { get; set; }
    }
}
