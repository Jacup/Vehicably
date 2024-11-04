using Vehicably.Domain.Entities.VehicleData;

namespace Vehicably.Domain.Entities.Vehicles;

public class Vehicle : DbObject
{
    public required VehicleBrand Brand { get; set; }

    public required VehicleModel Model { get; set; }
}
