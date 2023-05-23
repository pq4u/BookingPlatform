using BookingPlatform.Core.Exceptions;

namespace BookingPlatform.Application.Exceptions;

public class EmployeeNotFoundException : CustomException
{
    public Guid? Id { get; }
    
    public EmployeeNotFoundException() : base($"Employee with ID was not found.")
    {
    }
    
    public EmployeeNotFoundException(Guid id) : base($"Employee with ID: {id} was not found.")
    {
        Id = id;
    }
}