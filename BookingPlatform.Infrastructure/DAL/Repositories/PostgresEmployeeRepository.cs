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

    public Employee Get(EmployeeId id) =>
        _dbContext.Employees
            .Include(x => x.Bookings)
            .SingleOrDefault(x => x.Id == id);

    public IEnumerable<Employee> GetAll() =>
        _dbContext.Employees
            .Include(x => x.Bookings)
            .ToList();

    public void Add(Employee employee)
    {
        _dbContext.Add(employee);
        _dbContext.SaveChanges();
    }

    public void Update(Employee employee)
    {
        _dbContext.Update(employee);
        _dbContext.SaveChanges();
    }

    public void Delete(Employee employee)
    {
        _dbContext.Remove(employee);
        _dbContext.SaveChanges();
    }
}