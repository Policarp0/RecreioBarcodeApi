using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Location(1,'A',1,1,'A',1),
                new Location(2,'A',2,99,'B',1),
                new Location(3,'B',1,99,'C',1),
                new Location(4,'B',2,99,'D',2),
                new Location(5,'Z',99,99,'Z',99));
        }
    }
}
