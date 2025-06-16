using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Seeds
{
    public static class VardiyaTanimiSeed
    {
        public static void SeedVardiyaTanimlari(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VardiyaTanimi>().HasData(
                new VardiyaTanimi
                {
                    Id = 1,
                    VardiyaTipi = VardiyaTipi.Normal,
                    BaslangicSaati = new TimeSpan(8, 0, 0),   // 08:00
                    BitisSaati = new TimeSpan(17, 0, 0),     // 17:00
                    CumartesiCalismasi = false,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new VardiyaTanimi
                {
                    Id = 2,
                    VardiyaTipi = VardiyaTipi.Gunduz,
                    BaslangicSaati = new TimeSpan(7, 0, 0),   // 07:00
                    BitisSaati = new TimeSpan(15, 0, 0),     // 15:00
                    CumartesiCalismasi = true,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new VardiyaTanimi
                {
                    Id = 3,
                    VardiyaTipi = VardiyaTipi.A,
                    BaslangicSaati = new TimeSpan(7, 0, 0),   // 07:00
                    BitisSaati = new TimeSpan(15, 0, 0),     // 15:00
                    CumartesiCalismasi = true,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                },
                new VardiyaTanimi
                {
                    Id = 4,
                    VardiyaTipi = VardiyaTipi.B,
                    BaslangicSaati = new TimeSpan(15, 0, 0),  // 15:00
                    BitisSaati = new TimeSpan(23, 0, 0),     // 23:00
                    CumartesiCalismasi = false,
                    Aktif = true,
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
