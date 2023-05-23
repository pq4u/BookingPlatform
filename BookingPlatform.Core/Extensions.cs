using BookingPlatform.Core.DomainServices;
using BookingPlatform.Core.Polices;
using BookingPlatform.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingPlatform.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IBookingPolicy, BossBookingPolicy>();
        services.AddSingleton<IBookingPolicy, CustomerBookingPolicy>();

        services.AddSingleton<IBookingService, BookingService>();
        return services;
    }
}