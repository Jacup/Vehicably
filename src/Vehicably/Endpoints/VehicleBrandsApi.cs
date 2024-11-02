using MediatR;
using Vehicably.Application.Queries;

namespace Vehicably.Api.Endpoints;

public class VehicleBrandsApi : IApiMapper
{
    private const string Path = "vehicledata/brands";

    private readonly IMediator mediator;

    public VehicleBrandsApi(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public WebApplication Map(WebApplication app)
    {
        var group = app.MapGroup($"/api/{Path}");

        group.MapGet("/", async () => await GetAll())
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi();

        group.MapGet("/{id}", async (Guid id) => await GetById(id))
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        return app;
    }

    public async Task<IResult> GetAll()
    {
        var entities = await mediator.Send(new GetAllVehicleBrandsQuery());

        return Results.Ok(entities);
    }

    public async Task<IResult> GetById(Guid id)
    {
        var entity = await mediator.Send(new GetVehicleBrandByIdQuery() { Id = id });

        if (entity == null)
            return Results.NotFound();

        return Results.Ok(entity);
    }
}
