using BookingPlatform.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookingPlatform.Infrastructure.DAL;

internal sealed class DatabaseInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();

            var employees = dbContext.Employees.ToList();
            if (employees.Any())
            {
                return Task.CompletedTask;
            }
            employees = new List<Employee>()
            {
                new Employee(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Timothy Long"),
                new Employee(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Jack Blair"),
                new Employee(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Myrtle Pascall"),
                new Employee(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Lewis Russell"),
                new Employee(Guid.Parse("00000000-0000-0000-0000-000000000005"), "Marcus Palmer")
            };
            dbContext.Employees.AddRange(employees);
            dbContext.SaveChanges();
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}