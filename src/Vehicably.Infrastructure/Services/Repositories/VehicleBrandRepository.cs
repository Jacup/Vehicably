﻿using Vehicably.Domain.Models.Vehicles.VehicleData;
using Vehicably.Infrastructure.DAL;
using Vehicably.Infrastructure.Services.Interfaces;

namespace Vehicably.Infrastructure.Services.Repositories;

public class VehicleBrandRepository(VehicablyDbContext context) : Repository<VehicleBrand>(context), IVehicleBrandRepository
{
}
