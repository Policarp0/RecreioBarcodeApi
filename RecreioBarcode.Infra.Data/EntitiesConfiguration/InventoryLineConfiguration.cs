using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class InventoryLineConfiguration : IEntityTypeConfiguration<InventoryLine>
    {
        public void Configure(EntityTypeBuilder<InventoryLine> builder)
        {
            builder.ToTable("InventoryLines");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Count)
                .IsRequired()
                .HasDefaultValue(0)
                .HasPrecision(10,2);

            builder.Property(x => x.ItemCode)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(x => x.InventoryLocation)
                .WithMany(x => x.InventoryLines)
                .HasForeignKey(x => x.InventoryLocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            
            builder.HasIndex(x => new { x.InventoryLocationId, x.ItemCode })
                .IsUnique()
                .HasDatabaseName("UX_InventoryLines_InventoryLocation_ItemCode");
        }
    }
}
