using Vehicably.Application.Abstractions;
using Vehicably.Domain.Entities.VehicleData;
using Vehicably.Domain.Repositories;

namespace Vehicably.Application.VehicleData.Queries.Handlers;

public class GetAllVehicleBrandsQueryHandler : QueryHandlerBase<GetAllVehicleBrandsQuery, IEnumerable<VehicleBrand>>
{
    public GetAllVehicleBrandsQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async override Task<IEnumerable<VehicleBrand>> Handle(GetAllVehicleBrandsQuery request, CancellationToken cancellationToken)
    {
        return await UnitOfWork.VehicleBrandRepository.GetAllAsync();
    }
}
