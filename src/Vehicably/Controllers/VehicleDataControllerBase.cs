using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vehicably.Api.Controllers;

[ApiController]
public class VehicleDataControllerBase : ControllerBase
{
    public VehicleDataControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IMediator Mediator { get; set; }
}
