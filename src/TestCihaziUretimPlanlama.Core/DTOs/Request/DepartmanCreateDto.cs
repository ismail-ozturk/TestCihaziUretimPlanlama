using System.ComponentModel.DataAnnotations;

namespace TestCihaziUretimPlanlama.Core.DTOs.Request
{
    public class DepartmanCreateDto
    {
        [Required(ErrorMessage = "Departman adı zorunludur")]
        [StringLength(100, ErrorMessage = "Departman adı en fazla 100 karakter olabilir")]
        public string Ad { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Aciklama { get; set; }

        public bool Aktif { get; set; } = true;
    }

    public class DepartmanUpdateDto : DepartmanCreateDto
    {
        public int Id { get; set; }
    }
}
