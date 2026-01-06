using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new User(1,"Thiago"),
                new User(2,"Pedro"),
                new User(3,"Franklin"));
                
        }
    }
}
