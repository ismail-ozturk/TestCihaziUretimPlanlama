using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class GorevSeed
    {
        public static void SeedGorevler(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gorev>().HasData(
                // PMD Departmanı Görevleri
                new Gorev
                {
                    Id = 1,
                    Ad = "PV Hazırlama",
                    Aciklama = "PV hazırlama işlemleri",
                    DepartmanId = 1,
                    Sure = 32,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 2,
                    Ad = "Şematik Çizme ve Eksik Malzeme Kontrolü",
                    Aciklama = "Şematik çizim ve malzeme kontrol işlemleri",
                    DepartmanId = 1,
                    Sure = 32,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 3,
                    Ad = "Test Programı Hazırlama",
                    Aciklama = "Test programı hazırlama işlemleri",
                    DepartmanId = 1,
                    Sure = 40,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 7,
                    Ad = "Kablolama ve test adımları tek adım modunda kontrol (El Ölçümü)",
                    Aciklama = "Kablolama ve el ölçümü kontrol işlemleri",
                    DepartmanId = 1,
                    Sure = 5,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },

                // CNC Departmanı Görevleri
                new Gorev
                {
                    Id = 5,
                    Ad = "CNC Test Cihazı PCB Sabitleme",
                    Aciklama = "CNC ile PCB sabitleme işlemleri",
                    DepartmanId = 2,
                    Sure = 3,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 12,
                    Ad = "CNC Test Cihazı Üst Baskı",
                    Aciklama = "CNC ile üst baskı işlemleri",
                    DepartmanId = 2,
                    Sure = 8,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 16,
                    Ad = "CNC Manuel İş",
                    Aciklama = "CNC manuel işleme",
                    DepartmanId = 2,
                    Sure = 32,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 17,
                    Ad = "CNC Konsept Adaptör İşleme",
                    Aciklama = "CNC konsept adaptör işleme",
                    DepartmanId = 2,
                    Sure = 32,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 18,
                    Ad = "CNC Test Cihazı Plakası İşleme",
                    Aciklama = "CNC test cihazı plakası işleme",
                    DepartmanId = 2,
                    Sure = 16,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 19,
                    Ad = "CNC Test Cihazı Kontrol / Ayar",
                    Aciklama = "CNC test cihazı kontrol ve ayar işlemleri",
                    DepartmanId = 2,
                    Sure = 32,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },

                // Teknik Departmanı Görevleri
                new Gorev
                {
                    Id = 4,
                    Ad = "Malzeme Hazırlık",
                    Aciklama = "Malzeme hazırlık işlemleri",
                    DepartmanId = 3,
                    Sure = 3,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 6,
                    Ad = "Teknik Checklist",
                    Aciklama = "Teknik kontrol listesi işlemleri",
                    DepartmanId = 3,
                    Sure = 8,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 8,
                    Ad = "TP Kontrol ve İğne yerleştirme",
                    Aciklama = "Test programı kontrol ve iğne yerleştirme",
                    DepartmanId = 3,
                    Sure = 4,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 9,
                    Ad = "Pertenax ve Devre Hazırlığı",
                    Aciklama = "Pertenax ve devre hazırlık işlemleri",
                    DepartmanId = 3,
                    Sure = 10,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 10,
                    Ad = "Malzeme Sağlamlık Testi",
                    Aciklama = "Malzeme sağlamlık test işlemleri",
                    DepartmanId = 3,
                    Sure = 2,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 11,
                    Ad = "Etiketleme",
                    Aciklama = "Ürün etiketleme işlemleri",
                    DepartmanId = 3,
                    Sure = 3,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 13,
                    Ad = "Test Cihazı Kablolama ve Montaj",
                    Aciklama = "Test cihazı kablolama ve montaj işlemleri",
                    DepartmanId = 3,
                    Sure = 24,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 14,
                    Ad = "Test Cihazı Malzeme Yerleştirme",
                    Aciklama = "Test cihazı malzeme yerleştirme işlemleri",
                    DepartmanId = 3,
                    Sure = 3,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Gorev
                {
                    Id = 15,
                    Ad = "Şema ve Test Cihazı Kontrolü",
                    Aciklama = "Şema ve test cihazı kontrol işlemleri",
                    DepartmanId = 3,
                    Sure = 15,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
