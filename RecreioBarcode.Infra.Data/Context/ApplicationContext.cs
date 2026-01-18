using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.Context;

public class ApplicationContext : DbContext 
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    public DbSet<Inventory> Inventories { get; set; } = null!;
    public DbSet<InventoryItemOut> InventoryItemsOut { get; set; } = null!;
    public DbSet<InventoryLine> InventoryLines { get; set; } = null!;
    public DbSet<InventoryLocation> InventoryLocations { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }

}
