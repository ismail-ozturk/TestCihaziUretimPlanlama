using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class PersonelIzinConfiguration : IEntityTypeConfiguration<PersonelIzin>
    {
        public void Configure(EntityTypeBuilder<PersonelIzin> builder)
        {
            builder.ToTable("PersonelIzinleri");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BaslangicTarihi)
                .IsRequired();

            builder.Property(x => x.BitisTarihi)
                .IsRequired();

            builder.Property(x => x.Aciklama)
                .HasMaxLength(500);

            // Foreign Key
            builder.HasOne(x => x.Personel)
                .WithMany(x => x.Izinler)
                .HasForeignKey(x => x.PersonelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => x.PersonelId)
                .HasDatabaseName("IX_PersonelIzinleri_PersonelId");

            builder.HasIndex(x => new { x.BaslangicTarihi, x.BitisTarihi })
                .HasDatabaseName("IX_PersonelIzinleri_Tarih");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
