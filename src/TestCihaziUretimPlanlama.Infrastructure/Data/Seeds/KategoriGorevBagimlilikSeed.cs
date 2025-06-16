using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class KategoriGorevBagimlilikSeed
    {
        public static void SeedKategoriGorevBagimliliklari(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KategoriGorevBagimlilik>().HasData(
                // Görev 2 -> Görev 1'e bağımlı
                new KategoriGorevBagimlilik { Id = 1, OncuKategoriGorevSablonuId = 1, ArdilKategoriGorevSablonuId = 2, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 3 -> Görev 2'ye bağımlı
                new KategoriGorevBagimlilik { Id = 2, OncuKategoriGorevSablonuId = 2, ArdilKategoriGorevSablonuId = 3, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 18 -> Görev 1'e bağımlı
                new KategoriGorevBagimlilik { Id = 3, OncuKategoriGorevSablonuId = 1, ArdilKategoriGorevSablonuId = 4, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 8 -> Görev 2 ve 18'e bağımlı
                new KategoriGorevBagimlilik { Id = 4, OncuKategoriGorevSablonuId = 2, ArdilKategoriGorevSablonuId = 5, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },
                new KategoriGorevBagimlilik { Id = 5, OncuKategoriGorevSablonuId = 4, ArdilKategoriGorevSablonuId = 5, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 4 -> Görev 8'e bağımlı
                new KategoriGorevBagimlilik { Id = 6, OncuKategoriGorevSablonuId = 5, ArdilKategoriGorevSablonuId = 6, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 9 -> Görev 4'e bağımlı
                new KategoriGorevBagimlilik { Id = 7, OncuKategoriGorevSablonuId = 6, ArdilKategoriGorevSablonuId = 7, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 10 -> Görev 9'a bağımlı
                new KategoriGorevBagimlilik { Id = 8, OncuKategoriGorevSablonuId = 7, ArdilKategoriGorevSablonuId = 8, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 12 -> Görev 10'a bağımlı
                new KategoriGorevBagimlilik { Id = 9, OncuKategoriGorevSablonuId = 8, ArdilKategoriGorevSablonuId = 9, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 14 -> Görev 12'ye bağımlı
                new KategoriGorevBagimlilik { Id = 10, OncuKategoriGorevSablonuId = 9, ArdilKategoriGorevSablonuId = 10, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 13 -> Görev 14'e bağımlı
                new KategoriGorevBagimlilik { Id = 11, OncuKategoriGorevSablonuId = 10, ArdilKategoriGorevSablonuId = 11, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 11 -> Görev 13'e bağımlı
                new KategoriGorevBagimlilik { Id = 12, OncuKategoriGorevSablonuId = 11, ArdilKategoriGorevSablonuId = 12, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 15 -> Görev 11'e bağımlı
                new KategoriGorevBagimlilik { Id = 13, OncuKategoriGorevSablonuId = 12, ArdilKategoriGorevSablonuId = 13, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 6 -> Görev 15'e bağımlı
                new KategoriGorevBagimlilik { Id = 14, OncuKategoriGorevSablonuId = 13, ArdilKategoriGorevSablonuId = 14, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },

                // Görev 7 -> Görev 3 ve 6'ya bağımlı
                new KategoriGorevBagimlilik { Id = 15, OncuKategoriGorevSablonuId = 3, ArdilKategoriGorevSablonuId = 15, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow },
                new KategoriGorevBagimlilik { Id = 16, OncuKategoriGorevSablonuId = 14, ArdilKategoriGorevSablonuId = 15, BagimlilikTipi = BagimlilikTipi.FinishToStart, CreatedDate = DateTime.UtcNow }
            );
        }
    }
}
