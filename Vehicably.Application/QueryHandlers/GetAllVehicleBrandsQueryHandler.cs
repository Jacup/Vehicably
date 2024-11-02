using MediatR;
using Vehicably.Application.Queries;
using Vehicably.Domain.Models.Vehicles.VehicleData;
using Vehicably.Infrastructure.Services.Interfaces;

namespace Vehicably.Application.QueryHandlers;

public class GetAllVehicleBrandsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllVehicleBrandsQuery, IEnumerable<VehicleBrand>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<VehicleBrand>> Handle(GetAllVehicleBrandsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.VehicleBrandRepository.GetAllAsync();
    }
}
