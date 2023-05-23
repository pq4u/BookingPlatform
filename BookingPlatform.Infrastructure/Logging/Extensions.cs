using BookingPlatform.Application.Abstractions;
using BookingPlatform.Infrastructure.DAL.Decorators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BookingPlatform.Infrastructure.Logging;

public static class Extensions
{
    internal static IServiceCollection AddCustomLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        return services;
    }

    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration
                .WriteTo
                .Console()
                .WriteTo
                .File("/logs/logs.txt")
                .WriteTo
                .Seq("http://localhost:1411");
        });

        return builder;
    }
}