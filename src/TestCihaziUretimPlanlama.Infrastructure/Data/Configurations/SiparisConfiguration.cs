using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class SiparisConfiguration : IEntityTypeConfiguration<Siparis>
    {
        public void Configure(EntityTypeBuilder<Siparis> builder)
        {
            builder.ToTable("Siparisler");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UretimNumarasi)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Musteri)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.IstenilenBaslangicTarihi)
                .IsRequired();

            builder.Property(x => x.KategoriSablonuKullan)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.Durum)
                .IsRequired()
                .HasConversion<int>();
            // .HasDefaultValue(1) -> Bu satırı kaldırdık

            builder.Property(x => x.Oncelik)
                .IsRequired()
                .HasDefaultValue(5);

            builder.Property(x => x.Notlar)
                .HasMaxLength(1000);

            // Foreign Key
            builder.HasOne(x => x.Kategori)
                .WithMany(x => x.Siparisler)
                .HasForeignKey(x => x.KategoriId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(s => s.ZorunluPmdPersonel)
        .WithMany()
        .HasForeignKey(s => s.ZorunluPmdPersonelId)
        .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.ZorunluCncPersonel)
                .WithMany()
                .HasForeignKey(s => s.ZorunluCncPersonelId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.ZorunluTeknikPersonel)
                .WithMany()
                .HasForeignKey(s => s.ZorunluTeknikPersonelId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(x => x.UretimNumarasi)
                .IsUnique()
                .HasDatabaseName("IX_Siparisler_UretimNumarasi");

            builder.HasIndex(x => x.Durum)
                .HasDatabaseName("IX_Siparisler_Durum");

            builder.HasIndex(x => x.IstenilenBaslangicTarihi)
                .HasDatabaseName("IX_Siparisler_IstenilenBaslangicTarihi");

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
