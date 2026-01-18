using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;


namespace RecreioBarcode.Infra.Data.EntitiesConfiguration;

internal class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories", t =>
        {
            t.HasCheckConstraint(
                "Ck_Inventory_FinishedAt",
                "(IsActive = 1 AND FinishedAt IS NULL) OR (IsActive = 0 AND FinishedAt IS NOT NULL)");
            t.HasCheckConstraint(
                "CK_Inventories_ActiveOpen",
                "(IsActive = 1) OR (IsActive = 0 AND IsOpen = 0)");          
        });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.FinishedAt);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.IsOpen)
            .IsRequired();

        // Inventory -> InventoryLocations (1:N) (backing field(_locations))
        // -----------------------------
        builder.HasMany(x => x.InventoryLocations)
            .WithOne(x => x.Inventory)
            .HasForeignKey(x => x.InventoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.InventoryLocations)
            .UsePropertyAccessMode(PropertyAccessMode.Field);


        // Inventory -> InventoryItemsOut (1:N) (backing field(_itemsOut))
        // -----------------------------
        builder.HasMany(x => x.InventoryItemsOut)
            .WithOne(x => x.Inventory)
            .HasForeignKey(x => x.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.InventoryItemsOut)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
            

    }
}
