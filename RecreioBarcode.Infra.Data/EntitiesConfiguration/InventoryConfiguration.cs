using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;


namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    internal class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Inventory(1, "Inventário Teste", new DateTime(2026, 1, 6, 14, 59, 25, DateTimeKind.Utc), null, true, @"\TesteFilePath"),
                new Inventory(2, "Inventário Teste 2", new DateTime(2026, 1, 6, 14, 59, 25, DateTimeKind.Utc), new DateTime(2026, 1, 6, 14, 59, 25, DateTimeKind.Utc), false, @"\\TesteFilePath2"));      
        }
    }
}
