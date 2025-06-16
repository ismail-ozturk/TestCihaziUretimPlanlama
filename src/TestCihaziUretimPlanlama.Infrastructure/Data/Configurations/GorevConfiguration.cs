using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class GorevConfiguration : IEntityTypeConfiguration<Gorev>
    {
        public void Configure(EntityTypeBuilder<Gorev> builder)
        {
            builder.ToTable("Gorevler");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ad)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Aciklama)
                .HasMaxLength(1000);

            builder.Property(x => x.Sure)
                .IsRequired();

            builder.Property(x => x.Aktif)
                .IsRequired()
                .HasDefaultValue(true);

            // Foreign Key
            builder.HasOne(x => x.Departman)
                .WithMany(x => x.Gorevler)
                .HasForeignKey(x => x.DepartmanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.DepartmanId)
                .HasDatabaseName("IX_Gorevler_DepartmanId");

            builder.HasIndex(x => new { x.DepartmanId, x.Ad })
                .IsUnique()
                .HasDatabaseName("IX_Gorevler_DepartmanId_Ad");

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
