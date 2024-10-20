using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Vehicably.Infrastructure.DAL;

public class VehicablyDbContext : DbContext
{
    public VehicablyDbContext() : base() { }

    public VehicablyDbContext(DbContextOptions<VehicablyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}