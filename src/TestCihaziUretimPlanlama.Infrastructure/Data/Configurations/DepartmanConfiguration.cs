using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class DepartmanConfiguration : IEntityTypeConfiguration<Departman>
    {
        public void Configure(EntityTypeBuilder<Departman> builder)
        {
            builder.ToTable("Departmanlar");

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
                .HasDatabaseName("IX_Departmanlar_Ad");

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
