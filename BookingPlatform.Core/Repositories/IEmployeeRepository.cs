using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Repositories;

public interface IEmployeeRepository
{
    Employee Get(EmployeeId id);
    IEnumerable<Employee> GetAll();
    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
}