using Vehicably.Domain.Entities.VehicleData;
using Vehicably.Domain.Repositories.VehicleData;
using Vehicably.Infrastructure.DAL;

namespace Vehicably.Infrastructure.Services.Repositories;

public class VehicleBrandRepository(VehicablyDbContext context) : Repository<VehicleBrand>(context), IVehicleBrandRepository
{
}
