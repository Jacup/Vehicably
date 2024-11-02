using Microsoft.EntityFrameworkCore;
using Vehicably.Application.Extensions;
using Vehicably.Extensions;
using Vehicably.Infrastructure.DAL;

namespace Vehicably;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddApplication();
        builder.RegisterServices();

        var connectionString = builder.Configuration.GetConnectionString("VehicablyDbConnection");
        builder.Services.ConfigureDbContext(connectionString);
        
        var app = builder.Build();

        app.RegisterMiddleware();
        app.MapEndpoints();

        app.Run();
    }
}
