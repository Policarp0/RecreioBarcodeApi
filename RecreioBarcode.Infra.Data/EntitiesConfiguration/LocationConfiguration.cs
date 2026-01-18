using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations", t =>
            {
                t.HasCheckConstraint("CK_Locations_Rua", "Rua BETWEEN 1 AND 99");
                t.HasCheckConstraint("CK_Locations_Estante", "Estante BETWEEN 1 AND 999");
                t.HasCheckConstraint("CK_Locations_Numero", "Numero BETWEEN 1 AND 999");
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Zona)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.Rua)
                .IsRequired();

            builder.Property(x => x.Estante)
                .IsRequired();

            builder.Property(x => x.Prateleira)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.Zona, x.Rua, x.Estante, x.Prateleira, x.Numero
            })
                .IsUnique()
                .HasDatabaseName("UX_Location_Zona_Rua_Estante_Prateleira_numero");
        }
    }
}
