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
                new Inventory(1, "Inventário Teste", null, true, @"\TesteFilePath"),
                new Inventory(2, "Inventário Teste 2", null, false, @"\\TesteFilePath2"));      
        }
    }
}
