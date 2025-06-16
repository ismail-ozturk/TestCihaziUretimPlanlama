using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class UretimGoreviConfiguration : IEntityTypeConfiguration<UretimGorevi>
    {
        public void Configure(EntityTypeBuilder<UretimGorevi> builder)
        {
            builder.ToTable("UretimGorevleri");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sure)
                .IsRequired();

            builder.Property(x => x.Durum)
                .IsRequired()
                .HasConversion<int>();
            // .HasDefaultValue(1) -> Bu satırı kaldırdık

            builder.Property(x => x.Notlar)
     .HasMaxLength(1000)
     .IsRequired(false); // NOT NULL constraint'i kaldır

            // Foreign Keys
            builder.HasOne(x => x.Siparis)
                .WithMany(x => x.UretimGorevleri)
                .HasForeignKey(x => x.SiparisId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Gorev)
                .WithMany(x => x.UretimGorevleri)
                .HasForeignKey(x => x.GorevId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AtananPersonel)
                .WithMany(x => x.AtanmisGorevler)
                .HasForeignKey(x => x.AtananPersonelId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(x => x.SiparisId)
                .HasDatabaseName("IX_UretimGorevleri_SiparisId");

            builder.HasIndex(x => x.AtananPersonelId)
                .HasDatabaseName("IX_UretimGorevleri_AtananPersonelId");

            builder.HasIndex(x => x.Durum)
                .HasDatabaseName("IX_UretimGorevleri_Durum");

            builder.HasIndex(x => x.PlanlananBaslangic)
                .HasDatabaseName("IX_UretimGorevleri_PlanlananBaslangic");

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
