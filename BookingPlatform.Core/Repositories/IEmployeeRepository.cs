using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetAsync(EmployeeId id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
}