using MediatR;
using Vehicably.Domain.Entities.VehicleData;

namespace Vehicably.Application.VehicleData.Queries;

public class GetAllVehicleBrandsQuery : IRequest<IEnumerable<VehicleBrand>>
{
}
