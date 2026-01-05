using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class InventoryLocationConfiguration : IEntityTypeConfiguration<InventoryLocation>
    {
        public void Configure(EntityTypeBuilder<InventoryLocation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Location).WithMany(x => x.InventoryLocations).HasForeignKey(x => x.LocationId);
            builder.HasOne(x => x.Inventory).WithMany(x => x.InventoryLocations).HasForeignKey(x => x.InventoryId);
            builder.HasOne(x => x.User).WithMany(x => x.InventoryLocations).HasForeignKey(x => x.UserId);
        }
    }
}
