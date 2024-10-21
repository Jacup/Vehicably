using MediatR;
using Vehicably.Infrastructure.Services.Interfaces;
using Vehicably.Requests.Query;

namespace Vehicably.Endpoints;

public static class VehicleBrandsApi
{
    private const string Path = "vehicledata/brands";

    public static RouteGroupBuilder MapVehicleBrandsApi(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", async (IMediator mediator) =>
        {
            var results = await mediator.Send(new GetAllVehicleBrandsQuery());

            return Results.Ok(results);
        })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();




        return builder;
    }
}
