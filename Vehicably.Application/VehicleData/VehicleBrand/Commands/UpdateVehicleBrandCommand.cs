using MediatR;
using Vehicably.Domain.Entities.VehicleData;

namespace Vehicably.Application.VehicleData.Commands;

public class UpdateVehicleBrandCommand(string name) : IRequest<VehicleBrand>
{
    public required string Name { get; set; } = name;
}
