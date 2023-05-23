using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.DTO;
using BookingPlatform.Application.Queries;
using BookingPlatform.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Infrastructure.Handlers;

internal sealed class GetEmployeesHandler : IQueryHandler<GetEmployees, IEnumerable<EmployeeDto>>
{
    private readonly ApplicationDbContext _dbContext;
    
    public GetEmployeesHandler(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<EmployeeDto>> HandleAsync(GetEmployees query)
    {
        var employees = await _dbContext.Employees
            .Include(x => x.Bookings)
            .AsNoTracking()
            .ToListAsync();

        return employees.Select(x => x.AsDto());
    }
}