using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Infrastructure.Data.Seeds;

namespace TestCihaziUretimPlanlama.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<VardiyaTanimi> VardiyaTanimlari { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<KategoriGorevSablonu> KategoriGorevSablonlari { get; set; }
        public DbSet<KategoriGorevBagimlilik> KategoriGorevBagimliliklari { get; set; }
        public DbSet<PersonelGorevYetkinlik> PersonelGorevYetkinlikleri { get; set; }
        public DbSet<PersonelIzin> PersonelIzinleri { get; set; }
        public DbSet<PlanDisiTarih> PlanDisiTarihler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<UretimGorevi> UretimGorevleri { get; set; }
        public DbSet<UretimGorevBagimlilik> UretimGorevBagimliliklari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration'ları uygula
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            DepartmanSeed.SeedDepartmanlar(modelBuilder);
            VardiyaTanimiSeed.SeedVardiyaTanimlari(modelBuilder);
            GorevSeed.SeedGorevler(modelBuilder);
            KategoriSeed.SeedKategoriler(modelBuilder);
            KategoriGorevSablonuSeed.SeedKategoriGorevSablonlari(modelBuilder);
            KategoriGorevBagimlilikSeed.SeedKategoriGorevBagimliliklari(modelBuilder);
            PersonelSeed.SeedPersoneller(modelBuilder);
            PersonelGorevYetkinlikSeed.SeedPersonelGorevYetkinlikleri(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedDate = DateTime.UtcNow;
                }
            }
        }
    }
}
