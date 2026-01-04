using Microsoft.EntityFrameworkCore;
using RecreioBarcodeApi.Entities;

namespace RecreioBarcodeApi.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        DbSet<Inventory> Inventories { get; set; }
        DbSet<InventoryItemOut> InventoryItemsOut { get; set; }
        DbSet<InventoryLine> InventoryLines { get; set; }
        DbSet<InventoryLocation> InventoryLocations { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
