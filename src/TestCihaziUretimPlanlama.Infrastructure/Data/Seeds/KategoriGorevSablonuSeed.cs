using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class KategoriGorevSablonuSeed
    {
        public static void SeedKategoriGorevSablonlari(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KategoriGorevSablonu>().HasData(
                new KategoriGorevSablonu { Id = 1, KategoriId = 1, GorevId = 1, Sira = 1, OzelSure = 32, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 2, KategoriId = 1, GorevId = 2, Sira = 2, OzelSure = 32, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 3, KategoriId = 1, GorevId = 3, Sira = 3, OzelSure = 40, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 4, KategoriId = 1, GorevId = 18, Sira = 4, OzelSure = 16, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 5, KategoriId = 1, GorevId = 8, Sira = 5, OzelSure = 4, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 6, KategoriId = 1, GorevId = 4, Sira = 6, OzelSure = 3, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 7, KategoriId = 1, GorevId = 9, Sira = 7, OzelSure = 10, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 8, KategoriId = 1, GorevId = 10, Sira = 8, OzelSure = 2, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 9, KategoriId = 1, GorevId = 12, Sira = 9, OzelSure = 8, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 10, KategoriId = 1, GorevId = 14, Sira = 10, OzelSure = 3, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 11, KategoriId = 1, GorevId = 13, Sira = 11, OzelSure = 24, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 12, KategoriId = 1, GorevId = 11, Sira = 12, OzelSure = 3, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 13, KategoriId = 1, GorevId = 15, Sira = 13, OzelSure = 15, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 14, KategoriId = 1, GorevId = 6, Sira = 14, OzelSure = 8, CreatedDate = DateTime.UtcNow },
                new KategoriGorevSablonu { Id = 15, KategoriId = 1, GorevId = 7, Sira = 15, OzelSure = 5, CreatedDate = DateTime.UtcNow }
            );
        }
    }
}
