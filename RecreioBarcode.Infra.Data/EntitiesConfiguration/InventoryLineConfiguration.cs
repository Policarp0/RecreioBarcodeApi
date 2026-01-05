using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class InventoryLineConfiguration : IEntityTypeConfiguration<InventoryLine>
    {
        public void Configure(EntityTypeBuilder<InventoryLine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.InventoryLocation).WithMany(x => x.InventoryLines).HasForeignKey(x => x.InventoryLocationId);

            builder.HasData(
                new InventoryLine(1, "jzz105150ab", 1));
        }
    }
}
