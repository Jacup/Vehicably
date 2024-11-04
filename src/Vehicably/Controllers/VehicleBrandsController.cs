using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicably.Application.VehicleData.Commands;
using Vehicably.Application.VehicleData.Queries;
using Vehicably.Domain.Entities.VehicleData;
using Vehicably.Domain.Exceptions;

namespace Vehicably.Api.Controllers;

[Route($"/api/vehicleData/brands")]
public class VehicleBrandsController(IMediator mediator) : VehicleDataControllerBase(mediator)
{
    [HttpGet]
    [ProducesResponseType<VehicleBrand>(StatusCodes.Status200OK)]
    public async Task<IResult> GetAllAsync()
    {
        var entities = await Mediator.Send(new GetAllVehicleBrandsQuery());

        return Results.Ok(entities);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<VehicleBrand>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var entity = await Mediator.Send(new GetVehicleBrandByIdQuery(id));

        if (entity == null)
            return Results.NotFound();

        return Results.Ok(entity);
    }

    [HttpPost]
    [ProducesResponseType<VehicleBrand>(StatusCodes.Status201Created)]
    public async Task<IResult> AddAsync([FromBody] AddVehicleBrandCommand command)
    {
        var entity = await Mediator.Send(command);

        return Results.Created($"{entity.Id}", entity);
    }

    [HttpPut]
    [ProducesResponseType<VehicleBrand>(StatusCodes.Status200OK)]
    public async Task<IResult> UpdateAsync(Guid id, [FromBody] UpdateVehicleBrandCommand command)
    {
        VehicleBrand entity;

        try
        {
            entity = await Mediator.Send(command);
        }
        catch (EntityNotFoundException<VehicleBrand> e)
        {
            return Results.NotFound(e.Message);
        }

        return Results.Ok(entity);
    }
}
