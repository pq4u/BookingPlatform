using BookingPlatform.Infrastructure.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BookingPlatform.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPostgres();

        return services;
    }
}