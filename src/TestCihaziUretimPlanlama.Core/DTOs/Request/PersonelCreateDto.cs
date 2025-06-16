using System.ComponentModel.DataAnnotations;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.DTOs.Request
{
    public class PersonelCreateDto
    {
        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(100, ErrorMessage = "Ad en fazla 100 karakter olabilir")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(100, ErrorMessage = "Soyad en fazla 100 karakter olabilir")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Personel numarası zorunludur")]
        [StringLength(50, ErrorMessage = "Personel numarası en fazla 50 karakter olabilir")]
        public string PersonelNo { get; set; }

        [Required(ErrorMessage = "Departman seçimi zorunludur")]
        public int DepartmanId { get; set; }

        [Required(ErrorMessage = "Çalışma şekli seçimi zorunludur")]
        public CalismaSekli CalismaSekli { get; set; }

        // Sabit çalışma için
        public VardiyaTipi? SabitVardiyaTipi { get; set; }

        // Döner çalışma için
        public VardiyaTipi? DonerVardiyaBaslangicTipi { get; set; }
        public DateTime? DonerVardiyaBaslangicTarihi { get; set; }

        public bool Aktif { get; set; } = true;

        public List<int> GorevYetkinlikleri { get; set; } = new List<int>();
    }

    public class PersonelUpdateDto : PersonelCreateDto
    {
        public int Id { get; set; }
    }
}
