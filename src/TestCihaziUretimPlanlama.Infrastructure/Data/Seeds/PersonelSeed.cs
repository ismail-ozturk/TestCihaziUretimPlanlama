using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class PersonelSeed
    {
        public static void SeedPersoneller(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasData(
                new Personel
                {
                    Id = 1,
                    Ad = "Kaan",
                    Soyad = "Karamancı",
                    PersonelNo = "P001",
                    DepartmanId = 1,
                    CalismaSekli = CalismaSekli.Sabit,
                    SabitVardiyaTipi = VardiyaTipi.Normal,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 2,
                    Ad = "Mert",
                    Soyad = "Göncü",
                    PersonelNo = "P002",
                    DepartmanId = 1,
                    CalismaSekli = CalismaSekli.Sabit,
                    SabitVardiyaTipi = VardiyaTipi.Normal,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 3,
                    Ad = "Kadir",
                    Soyad = "Vural",
                    PersonelNo = "P003",
                    DepartmanId = 2,
                    CalismaSekli = CalismaSekli.Doner,
                    DonerVardiyaBaslangicTipi = VardiyaTipi.A,
                    DonerVardiyaBaslangicTarihi = new DateTime(2025, 3, 10),
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 4,
                    Ad = "Ramazan",
                    Soyad = "Öztürk",
                    PersonelNo = "P004",
                    DepartmanId = 2,
                    CalismaSekli = CalismaSekli.Sabit,
                    SabitVardiyaTipi = VardiyaTipi.Gunduz,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 5,
                    Ad = "Adem",
                    Soyad = "Yüksel",
                    PersonelNo = "P005",
                    DepartmanId = 2,
                    CalismaSekli = CalismaSekli.Sabit,
                    SabitVardiyaTipi = VardiyaTipi.Gunduz,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 6,
                    Ad = "Sinan",
                    Soyad = "Tekyol",
                    PersonelNo = "P006",
                    DepartmanId = 3,
                    CalismaSekli = CalismaSekli.Doner,
                    DonerVardiyaBaslangicTipi = VardiyaTipi.A,
                    DonerVardiyaBaslangicTarihi = new DateTime(2025, 3, 10),
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 7,
                    Ad = "Emre",
                    Soyad = "Kahveci",
                    PersonelNo = "P007",
                    DepartmanId = 3,
                    CalismaSekli = CalismaSekli.Doner,
                    DonerVardiyaBaslangicTipi = VardiyaTipi.B,
                    DonerVardiyaBaslangicTarihi = new DateTime(2025, 3, 10),
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 8,
                    Ad = "Nuri",
                    Soyad = "Ersipahi",
                    PersonelNo = "P008",
                    DepartmanId = 3,
                    CalismaSekli = CalismaSekli.Sabit,
                    SabitVardiyaTipi = VardiyaTipi.Normal,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 9,
                    Ad = "Mustafa",
                    Soyad = "Durgun",
                    PersonelNo = "P009",
                    DepartmanId = 1,
                    CalismaSekli = CalismaSekli.Doner,
                    DonerVardiyaBaslangicTipi = VardiyaTipi.A,
                    DonerVardiyaBaslangicTarihi = new DateTime(2025, 3, 10),
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 10,
                    Ad = "Mehmet Ali",
                    Soyad = "Binici",
                    PersonelNo = "P010",
                    DepartmanId = 1,
                    CalismaSekli = CalismaSekli.Doner,
                    DonerVardiyaBaslangicTipi = VardiyaTipi.B,
                    DonerVardiyaBaslangicTarihi = new DateTime(2025, 3, 10),
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Personel
                {
                    Id = 11,
                    Ad = "İbrahim",
                    Soyad = "Gelen",
                    PersonelNo = "P011",
                    DepartmanId = 3,
                    CalismaSekli = CalismaSekli.Sabit,
                    SabitVardiyaTipi = VardiyaTipi.Normal,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
