using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Repositories;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees;

    public InMemoryEmployeeRepository()
    {
        _employees = new List<Employee>()
        {
            new Employee(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Jan Kowalski"),
            new Employee(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Amadeusz Zalewski"),
            new Employee(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Norbert Kubica")
        };
    }

    public Employee Get(EmployeeId id)
        => _employees.SingleOrDefault(x => x.Id == id);

    public IEnumerable<Employee> GetAll()
        => _employees;

    public void Add(Employee room)
        => _employees.Add(room);

    public void Update(Employee room)
    {
    }

    public void Delete(Employee room)
        => _employees.Remove(room);
}