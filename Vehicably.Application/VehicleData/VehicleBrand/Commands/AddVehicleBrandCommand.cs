using MediatR;
using Vehicably.Domain.Entities.VehicleData;

namespace Vehicably.Application.VehicleData.Commands;

public class AddVehicleBrandCommand(string name) : IRequest<VehicleBrand>
{
    public required string Name { get; set; } = name;
}
