using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Infrastructure.Data.Configurations
{
    public class PersonelGorevYetkinlikConfiguration : IEntityTypeConfiguration<PersonelGorevYetkinlik>
    {
        public void Configure(EntityTypeBuilder<PersonelGorevYetkinlik> builder)
        {
            builder.ToTable("PersonelGorevYetkinlikleri");

            builder.HasKey(x => x.Id);

            // Foreign Keys
            builder.HasOne(x => x.Personel)
                .WithMany(x => x.GorevYetkinlikleri)
                .HasForeignKey(x => x.PersonelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Gorev)
                .WithMany(x => x.PersonelYetkinlikleri)
                .HasForeignKey(x => x.GorevId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint
            builder.HasIndex(x => new { x.PersonelId, x.GorevId })
                .IsUnique()
                .HasDatabaseName("IX_PersonelGorevYetkinlikleri_PersonelId_GorevId");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
