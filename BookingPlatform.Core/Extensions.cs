using BookingPlatform.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingPlatform.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();

        return services;
    }
}