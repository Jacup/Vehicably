namespace Vehicably.Domain.Models.Vehicles.VehicleData;

public class VehicleBrand : DbObject
{
    public required string Name { get; set; }

    public ICollection<VehicleModel> Models { get; set; } = [];
}