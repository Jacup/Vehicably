namespace Vehicably.Infrastructure.Services.Interfaces;

public interface IUnitOfWork
{
    IVehicleBrandRepository VehicleBrandRepository { get; }

    IVehicleModelRepository VehicleModelRepository { get; }

    Task<T> ExecuteAsync<T>(Func<Task<T>> action);
}
