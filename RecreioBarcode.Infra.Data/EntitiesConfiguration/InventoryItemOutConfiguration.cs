using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class InventoryItemOutConfiguration : IEntityTypeConfiguration<InventoryItemOut>
    {
        public void Configure(EntityTypeBuilder<InventoryItemOut> builder)
        {
            builder.ToTable("InventoryItemsOut");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ItemCode)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(x => x.Count)
                .IsRequired()
                .HasDefaultValue(1m)
                .HasPrecision(10,2);

            builder.HasOne(x => x.Inventory)
                .WithMany(x => x.InventoryItemsOut)
                .IsRequired()
                .HasForeignKey(x => x.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.FoundLocation)
                .WithMany()
                .HasForeignKey(x => x.FoundLocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
