using Microsoft.EntityFrameworkCore;
using Vehicably.Domain.Entities;
using Vehicably.Domain.Repositories;
using Vehicably.Domain.Repositories.VehicleData;
using Vehicably.Infrastructure.DAL;

namespace Vehicably.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VehicablyDbContext context;

    public UnitOfWork(
        VehicablyDbContext context,
        IVehicleBrandRepository vehicleBrandRepository,
        IVehicleModelRepository vehicleModelRepository)
    {
        this.context = context;
        VehicleBrandRepository = vehicleBrandRepository;
        VehicleModelRepository = vehicleModelRepository;
    }

    public IVehicleBrandRepository VehicleBrandRepository { get; private set; }

    public IVehicleModelRepository VehicleModelRepository { get; private set; }

    public void Dispose() => context.Dispose();

    public async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var result = await action();
            
            UpdateTimestamps();

            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return result;
        }
        catch (Exception)
        {
            await context.Database.RollbackTransactionAsync();
            throw;
        }
    }

    private void UpdateTimestamps()
    {
        var datetime = DateTime.Now;

        var entries = context.ChangeTracker.Entries()
            .Where(entry => entry.Entity is DbObject && (entry.State == EntityState.Added || entry.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            entry.Property("UpdatedDate").CurrentValue = datetime;

            if (entry.State == EntityState.Added)
                entry.Property("CreatedDate").CurrentValue = datetime;
        }
    }
}
