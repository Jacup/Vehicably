using MediatR;
using Vehicably.Domain.Models.Vehicles.VehicleData;

namespace Vehicably.Requests.Query;

public class GetAllVehicleBrandsQuery : IRequest<IEnumerable<VehicleBrand>>
{
}
