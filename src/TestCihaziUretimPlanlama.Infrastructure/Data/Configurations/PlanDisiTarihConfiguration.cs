// PlanDisiTarihConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class PlanDisiTarihConfiguration : IEntityTypeConfiguration<PlanDisiTarih>
    {
        public void Configure(EntityTypeBuilder<PlanDisiTarih> builder)
        {
            builder.ToTable("PlanDisiTarihler");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tarih)
                .IsRequired();

            builder.Property(x => x.Aciklama)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.TekrarliMi)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasIndex(x => x.Tarih)
                .HasDatabaseName("IX_PlanDisiTarihler_Tarih");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
