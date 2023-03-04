using BookingPlatform.Core.Repositories;
using BookingPlatform.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookingPlatform.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        const string connectionString = "Host=localhost;Port=5432;Database=BookingPlatform;Username=postgres;Password=";
        services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString));
        services.AddScoped<IEmployeeRepository, PostgresEmployeeRepository>();
        services.AddHostedService<DatabaseInitializer>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }
}