using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.Context;

public class ApplicationContext : DbContext 
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryItemOut> InventoryItemsOut { get; set; }
    public DbSet<InventoryLine> InventoryLines { get; set; }
    public DbSet<InventoryLocation> InventoryLocations { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
