using Vehicably.Domain.Models.Vehicles.VehicleData;

namespace Vehicably.Domain.Models.Vehicles;

public class Vehicle : DbObject
{
    public required VehicleBrand Brand { get; set; }

    public required VehicleModel Model { get; set; }
}
