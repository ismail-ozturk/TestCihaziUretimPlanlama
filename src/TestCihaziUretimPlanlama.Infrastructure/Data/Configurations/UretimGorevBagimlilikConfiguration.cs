using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class UretimGorevBagimlilikConfiguration : IEntityTypeConfiguration<UretimGorevBagimlilik>
    {
        public void Configure(EntityTypeBuilder<UretimGorevBagimlilik> builder)
        {
            builder.ToTable("UretimGorevBagimliliklari");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BagimlilikTipi)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.GecikmeGunu)
                .IsRequired()
                .HasDefaultValue(0);

            // Foreign Keys - Manuel olarak tanımlayalım
            builder.HasOne(x => x.OncuGorev)
                .WithMany(x => x.ArdilBagimliliklar)
                .HasForeignKey(x => x.OncuUretimGoreviId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ArdilGorev)
                .WithMany(x => x.OncuBagimliliklar)
                .HasForeignKey(x => x.ArdilUretimGoreviId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => new { x.OncuUretimGoreviId, x.ArdilUretimGoreviId })
                .IsUnique()
                .HasDatabaseName("IX_UretimGorevBagimliliklari_Oncu_Ardil");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
