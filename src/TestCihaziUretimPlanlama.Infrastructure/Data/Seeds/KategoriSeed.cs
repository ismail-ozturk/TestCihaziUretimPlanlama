using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class KategoriSeed
    {
        public static void SeedKategoriler(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori
                {
                    Id = 1,
                    Ad = "İğne Plakası",
                    Aciklama = "İğne plakası üretim kategorisi",
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
