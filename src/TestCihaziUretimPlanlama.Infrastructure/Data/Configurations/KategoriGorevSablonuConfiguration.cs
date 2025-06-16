using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class KategoriGorevSablonuConfiguration : IEntityTypeConfiguration<KategoriGorevSablonu>
    {
        public void Configure(EntityTypeBuilder<KategoriGorevSablonu> builder)
        {
            builder.ToTable("KategoriGorevSablonlari");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sira)
                .IsRequired();

            // Foreign Keys
            builder.HasOne(x => x.Kategori)
                .WithMany(x => x.GorevSablonlari)
                .HasForeignKey(x => x.KategoriId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Gorev)
                .WithMany(x => x.KategoriSablonlari)
                .HasForeignKey(x => x.GorevId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => new { x.KategoriId, x.GorevId })
                .IsUnique()
                .HasDatabaseName("IX_KategoriGorevSablonlari_KategoriId_GorevId");

            builder.HasIndex(x => new { x.KategoriId, x.Sira })
                .IsUnique()
                .HasDatabaseName("IX_KategoriGorevSablonlari_KategoriId_Sira");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
