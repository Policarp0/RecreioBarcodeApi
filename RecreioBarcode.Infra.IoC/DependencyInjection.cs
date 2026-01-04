
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecreioBarcode.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Application.Mappings;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Repositories;

namespace RecreioBarcode.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register infrastructure services here, e.g., database context, repositories, etc.

            services.AddDbContext<ApplicationContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddAutoMapper(cfg => cfg.AddProfile<DomainToDTOMappingProfile>());

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryLocationRepository, InventoryLocationRepository>();
            services.AddScoped<IInventoryLineRepository, InventoryLineRepository>();
            services.AddScoped<IInventoryItemOutRepository, InventoryItemOutRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
