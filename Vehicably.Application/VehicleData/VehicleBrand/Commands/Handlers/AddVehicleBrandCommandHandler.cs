using Vehicably.Application.Abstractions;
using Vehicably.Domain.Entities.VehicleData;
using Vehicably.Domain.Repositories;

namespace Vehicably.Application.VehicleData.Commands.Handlers;

public class AddVehicleBrandCommandHandler : CommandHandlerBase<AddVehicleBrandCommand, VehicleBrand>
{
    public AddVehicleBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async override Task<VehicleBrand> Handle(AddVehicleBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = new VehicleBrand() { Id = Guid.NewGuid(), Name = request.Name };

        await UnitOfWork.VehicleBrandRepository.InsertAsync(entity);

        return entity;
    }
}
