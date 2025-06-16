// VardiyaTanimiConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class VardiyaTanimiConfiguration : IEntityTypeConfiguration<VardiyaTanimi>
    {
        public void Configure(EntityTypeBuilder<VardiyaTanimi> builder)
        {
            builder.ToTable("VardiyaTanimlari");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.VardiyaTipi)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.BaslangicSaati)
                .IsRequired();

            builder.Property(x => x.BitisSaati)
                .IsRequired();

            builder.Property(x => x.CumartesiCalismasi)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.Aktif)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(x => x.VardiyaTipi)
                .IsUnique()
                .HasDatabaseName("IX_VardiyaTanimlari_VardiyaTipi");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
