using MediatR;
using Vehicably.Domain.Models.Vehicles.VehicleData;

namespace Vehicably.Application.Queries;

public class GetVehicleBrandByIdQuery : IRequest<VehicleBrand?>
{
    public Guid Id { get; set; }
}
