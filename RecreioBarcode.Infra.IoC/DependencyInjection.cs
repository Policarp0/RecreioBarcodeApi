
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecreioBarcode.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Application.Mappings;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Repositories;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Application.Services;
using RecreioBarcode.Infra.Data.UnitOfWork;
using RecreioBarcode.Domain.UnitOfWork;
using RecreioBarcode.Domain.Entities;

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

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //services.AddScoped<IRepository<Inventory>>, Repository<Inventory>>();
        //services.AddScoped<IInventoryLocationRepository, InventoryLocationRepository>();
        //services.AddScoped<IInventoryLineRepository, InventoryLineRepository>();
        //services.AddScoped<IInventoryItemOutRepository, InventoryItemOutRepository>();
        //services.AddScoped<ILocationRepository, LocationRepository>();
        //services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IInventoryService, InventoryService>();

        return services;
    }
}
