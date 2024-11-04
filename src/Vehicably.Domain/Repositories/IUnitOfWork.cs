using Vehicably.Domain.Repositories.VehicleData;

namespace Vehicably.Domain.Repositories;

public interface IUnitOfWork
{
    IVehicleBrandRepository VehicleBrandRepository { get; }

    IVehicleModelRepository VehicleModelRepository { get; }

    Task<T> ExecuteAsync<T>(Func<Task<T>> action);
}
