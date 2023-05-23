using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Repositories;
using BookingPlatform.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Infrastructure.DAL.Repositories;

public class PostgresEmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PostgresEmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Employee> GetAsync(EmployeeId id) =>
        _dbContext.Employees
            .Include(x => x.Bookings)
            .SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        var results = await _dbContext.Employees
            .Include(x => x.Bookings)
            .ToListAsync();

        return results.AsEnumerable();
    }
        

    public async Task AddAsync(Employee employee)
    {
       await _dbContext.AddAsync(employee);
    }

    public async Task UpdateAsync(Employee employee)
    {
        _dbContext.Update(employee);
    }

    public async Task DeleteAsync(Employee employee)
    {
        _dbContext.Remove(employee);
    }
}