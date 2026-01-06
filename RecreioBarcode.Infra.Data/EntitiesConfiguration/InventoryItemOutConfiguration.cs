using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class InventoryItemOutConfiguration : IEntityTypeConfiguration<InventoryItemOut>
    {
        public void Configure(EntityTypeBuilder<InventoryItemOut> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Inventory).WithMany(x => x.InventoryItemsOut).HasForeignKey(x => x.InventoryId);
            builder.HasOne(x => x.Location).WithMany(x => x.InventoryItemsOut).HasForeignKey(x => x.LocationId);
            builder.HasOne(x => x.User).WithMany(x => x.InventoryItemsOut).HasForeignKey(x => x.UserId);

        }
    }
}
