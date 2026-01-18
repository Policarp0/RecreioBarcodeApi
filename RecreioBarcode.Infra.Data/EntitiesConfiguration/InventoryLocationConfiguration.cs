using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class InventoryLocationConfiguration : IEntityTypeConfiguration<InventoryLocation>
    {
        public void Configure(EntityTypeBuilder<InventoryLocation> builder)
        {
            builder.ToTable("InventoryLocations", t =>
            {
                t.HasCheckConstraint(
                    "CK_InventoryLocations_InventoriedAt",
                    "(IsInventoried = 0 AND InventoriedAt IS NULL) OR (IsInventoried = 1 AND InventoriedAt IS NOT NULL)"
                );
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.InventoriedAt);

            builder.Property(x => x.IsInventoried)
                .IsRequired();
            

            // InventoryLocation -> Inventory (1:N)
            // -----------------------------
            builder.HasOne(x => x.Inventory)
                .WithMany(x => x.InventoryLocations)
                .HasForeignKey(x => x.InventoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // InventoryLocation -> Location (1:N)
            // -----------------------------
            builder.HasOne(x => x.Location)
                .WithMany() //Location NÃO tem navegação de volta para o domínio
                .HasForeignKey(x => x.LocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.InventoryId, x.LocationId })
                .IsUnique()
                .HasDatabaseName("UX_InventoryLocation_Inventory_Location");
            
            // InventoryLocation -> InventoryLine
            builder.HasMany(x => x.InventoryLines)
                .WithOne(x => x.InventoryLocation)
                .HasForeignKey(x => x.InventoryLocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.InventoryLines)
                .UsePropertyAccessMode(PropertyAccessMode.Field);



        }
    }
}
