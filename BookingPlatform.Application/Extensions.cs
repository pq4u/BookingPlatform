using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.DTO;
using BookingPlatform.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BookingPlatform.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ICommandHandler<>).Assembly;

        services.Scan(s => s.FromAssemblies(applicationAssembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        return services;
    }
}