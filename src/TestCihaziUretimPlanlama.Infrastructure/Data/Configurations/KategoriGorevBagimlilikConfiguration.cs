using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class KategoriGorevBagimlilikConfiguration : IEntityTypeConfiguration<KategoriGorevBagimlilik>
    {
        public void Configure(EntityTypeBuilder<KategoriGorevBagimlilik> builder)
        {
            builder.ToTable("KategoriGorevBagimliliklari");

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
                .HasForeignKey(x => x.OncuKategoriGorevSablonuId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ArdilGorev)
                .WithMany(x => x.OncuBagimliliklar)
                .HasForeignKey(x => x.ArdilKategoriGorevSablonuId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => new { x.OncuKategoriGorevSablonuId, x.ArdilKategoriGorevSablonuId })
                .IsUnique()
                .HasDatabaseName("IX_KategoriGorevBagimliliklari_Oncu_Ardil");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
