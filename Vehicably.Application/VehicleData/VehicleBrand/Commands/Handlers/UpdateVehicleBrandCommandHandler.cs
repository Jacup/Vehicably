using Vehicably.Application.Abstractions;
using Vehicably.Domain.Entities.VehicleData;
using Vehicably.Domain.Repositories;

namespace Vehicably.Application.VehicleData.Commands.Handlers;

public class UpdateVehicleBrandCommandHandler : CommandHandlerBase<UpdateVehicleBrandCommand, VehicleBrand>
{
    public UpdateVehicleBrandCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override async Task<VehicleBrand> Handle(UpdateVehicleBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = new VehicleBrand() { Name = request.Name };

        await UnitOfWork.VehicleBrandRepository.UpdateAsync(entity);

        return entity;
    }
}
