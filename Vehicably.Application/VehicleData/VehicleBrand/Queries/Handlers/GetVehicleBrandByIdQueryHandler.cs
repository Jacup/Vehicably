using MediatR;
using Vehicably.Domain.Entities.VehicleData;
using Vehicably.Domain.Repositories;

namespace Vehicably.Application.VehicleData.Queries.Handlers;

internal class GetVehicleBrandByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetVehicleBrandByIdQuery, VehicleBrand?>
{
    public async Task<VehicleBrand?> Handle(GetVehicleBrandByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.VehicleBrandRepository.GetByIdAsync(request.Id);
    }
}
