using MediatR;
using Vehicably.Domain.Entities.VehicleData;

namespace Vehicably.Application.VehicleData.Queries;

public class GetVehicleBrandByIdQuery(Guid id) : IRequest<VehicleBrand?>
{
    public Guid Id { get; set; } = id;
}
