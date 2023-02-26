using BookingPlatform.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingPlatform.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IBookingService, BookingService>();
        return services;
    }
}