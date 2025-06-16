using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.ToTable("Kategoriler");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ad)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Aciklama)
                .HasMaxLength(500);

            builder.Property(x => x.Aktif)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(x => x.Ad)
                .IsUnique()
                .HasDatabaseName("IX_Kategoriler_Ad");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
