using MediatR;
using Vehicably.Domain.Models.Vehicles.VehicleData;

namespace Vehicably.Application.Queries;

public class GetAllVehicleBrandsQuery : IRequest<IEnumerable<VehicleBrand>>
{
}
