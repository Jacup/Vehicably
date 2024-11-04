namespace Vehicably.Domain.Entities.VehicleData;

public class VehicleModel : DbObject
{
    public required string Name { get; set; }

    public required Guid BrandId { get; set; }

    public VehicleBrand Brand { get; set; }
}