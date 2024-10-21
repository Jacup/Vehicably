using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vehicably.Infrastructure.Services;
using Vehicably.Infrastructure.Services.Interfaces;
using Vehicably.Infrastructure.Services.Repositories;

namespace Vehicably.Infrastructure.DAL;

public static class DbContextExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
    {
        var serverVersion = new MariaDbServerVersion(new Version(10, 11, 8));

        services.AddDbContext<VehicablyDbContext>(options => options
            .UseMySql(connectionString, serverVersion, b => b.MigrationsAssembly("Vehicably.Infrastructure"))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

        services.AddScoped<IVehicleBrandRepository, VehicleBrandRepository>();
        services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
