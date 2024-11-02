using MediatR;
using Vehicably.Application.Queries;
using Vehicably.Domain.Models.Vehicles.VehicleData;
using Vehicably.Infrastructure.Services.Interfaces;

namespace Vehicably.Application.QueryHandlers;

internal class GetVehicleBrandByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetVehicleBrandByIdQuery, VehicleBrand?>
{
    public async Task<VehicleBrand?> Handle(GetVehicleBrandByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.VehicleBrandRepository.GetByIdAsync(request.Id);
    }
}
