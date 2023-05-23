using BookingPlatform.Application.Abstractions;
using BookingPlatform.Infrastructure.DAL;
using BookingPlatform.Infrastructure.Exceptions;
using BookingPlatform.Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingPlatform.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection("app");
        services.Configure<AppOptions>(section);
        
        services.AddSingleton<ExceptionMiddleware>();
        services.AddPostgres(configuration);
        
        var infrastructureAssembly = typeof(AppOptions).Assembly;

        services.Scan(s => s.FromAssemblies(infrastructureAssembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddCustomLogging();

        return services;
    }
    
    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();

        return app;
    }
}