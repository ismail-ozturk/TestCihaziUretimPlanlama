using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class PersonelGorevYetkinlikSeed
    {
        public static void SeedPersonelGorevYetkinlikleri(ModelBuilder modelBuilder)
        {
            var yetkinlikler = new List<PersonelGorevYetkinlik>();
            int id = 1;

            // Kaan Karamancı (Personel ID: 1) - Görevler: 1, 2, 3, 7
            yetkinlikler.AddRange(new[]
            {
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 1, GorevId = 1, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 1, GorevId = 2, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 1, GorevId = 3, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 1, GorevId = 7, CreatedDate = DateTime.UtcNow }
            });

            // Mert Göncü (Personel ID: 2) - Görevler: 1, 2, 3, 7
            yetkinlikler.AddRange(new[]
            {
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 2, GorevId = 1, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 2, GorevId = 2, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 2, GorevId = 3, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 2, GorevId = 7, CreatedDate = DateTime.UtcNow }
            });

            // Kadir Vural (Personel ID: 3) - Görevler: 5, 12, 16, 17, 18, 19
            yetkinlikler.AddRange(new[]
            {
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 3, GorevId = 5, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 3, GorevId = 12, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 3, GorevId = 16, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 3, GorevId = 17, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 3, GorevId = 18, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 3, GorevId = 19, CreatedDate = DateTime.UtcNow }
            });

            // Ramazan Öztürk (Personel ID: 4) - Görev: 5
            yetkinlikler.Add(new PersonelGorevYetkinlik { Id = id++, PersonelId = 4, GorevId = 5, CreatedDate = DateTime.UtcNow });

            // Adem Yüksel (Personel ID: 5) - Görev: 5
            yetkinlikler.Add(new PersonelGorevYetkinlik { Id = id++, PersonelId = 5, GorevId = 5, CreatedDate = DateTime.UtcNow });

            // Sinan Tekyol (Personel ID: 6) - Görevler: 4, 8, 9, 10, 11, 13, 14, 15
            yetkinlikler.AddRange(new[]
            {
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 4, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 8, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 9, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 10, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 11, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 13, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 14, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 6, GorevId = 15, CreatedDate = DateTime.UtcNow }
            });

            // Emre Kahveci (Personel ID: 7) - Görevler: 4, 8, 9, 10, 11, 13, 14, 15
            yetkinlikler.AddRange(new[]
            {
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 4, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 8, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 9, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 10, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 11, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 13, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 14, CreatedDate = DateTime.UtcNow },
                new PersonelGorevYetkinlik { Id = id++, PersonelId = 7, GorevId = 15, CreatedDate = DateTime.UtcNow }
            });

            // Nuri Ersipahi (Personel ID: 8) - Görev: 6
            yetkinlikler.Add(new PersonelGorevYetkinlik { Id = id++, PersonelId = 8, GorevId = 6, CreatedDate = DateTime.UtcNow });

            modelBuilder.Entity<PersonelGorevYetkinlik>().HasData(yetkinlikler);
        }
    }
}
