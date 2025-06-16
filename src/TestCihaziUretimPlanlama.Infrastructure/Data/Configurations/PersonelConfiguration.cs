using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class PersonelConfiguration : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.ToTable("Personeller");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ad)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Soyad)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PersonelNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CalismaSekli)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.SabitVardiyaTipi)
                .HasConversion<int>();

            builder.Property(x => x.DonerVardiyaBaslangicTipi)
                .HasConversion<int>();

            builder.Property(x => x.Aktif)
                .IsRequired()
                .HasDefaultValue(true);

            // Foreign Key
            builder.HasOne(x => x.Departman)
                .WithMany(x => x.Personeller)
                .HasForeignKey(x => x.DepartmanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => x.PersonelNo)
                .IsUnique()
                .HasDatabaseName("IX_Personeller_PersonelNo");

            builder.HasIndex(x => x.DepartmanId)
                .HasDatabaseName("IX_Personeller_DepartmanId");

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
