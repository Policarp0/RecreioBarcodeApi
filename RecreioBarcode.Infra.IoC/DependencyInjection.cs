
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecreioBarcode.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Application.Mappings;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Repositories;
using RecreioBarcode.Infra.Data.UnitOfWork;
using RecreioBarcode.Domain.UnitOfWork;


namespace RecreioBarcode.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register infrastructure services here, e.g., database context, repositories, etc.

        services.AddDbContext<ApplicationContext>(options =>
            options
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b=>b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));


        services.AddAutoMapper(cfg => cfg.AddProfile<DomainToDTOMappingProfile>());

        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
