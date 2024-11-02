using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vehicably.Application.Behaviors;

namespace Vehicably.Application.Extensions;

public static class ConfigurationExtensions
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ConfigurationExtensions)));

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkDecorator<,>));

        return builder;
    }
}
