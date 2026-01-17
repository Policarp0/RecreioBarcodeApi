using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Application.Mappings;
using RecreioBarcode.Application.Services;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Domain.UnitOfWork;
using RecreioBarcode.Infra.Data.Context;
using RecreioBarcode.Infra.Data.Repositories;
using RecreioBarcode.Infra.Data.UnitOfWork;

namespace RecreioBarcode.Infra.IoC;

public static class DependencyInjectionWebUI
{
    public static IServiceCollection AddInfrastructureWebUI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));


        services.AddAutoMapper(cfg => cfg.AddProfile<DomainToDTOMappingProfile>());

        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IInventoryService, InventoryService>();

        return services;
    }
}

