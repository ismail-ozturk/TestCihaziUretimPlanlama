using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class DepartmanSeed
    {
        public static void SeedDepartmanlar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departman>().HasData(
                new Departman
                {
                    Id = 1,
                    Ad = "PMD",
                    Aciklama = "PMD Test Departmanı",
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Departman
                {
                    Id = 2,
                    Ad = "CNC",
                    Aciklama = "CNC İşleme Departmanı",
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Departman
                {
                    Id = 3,
                    Ad = "Teknik",
                    Aciklama = "Test Tamir Bakım Departmanı",
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
