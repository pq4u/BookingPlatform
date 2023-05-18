using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Exceptions;

public sealed class CannotMakeBookingException : CustomException
{
    public EmployeeId EmployeeId { get; }
    public CannotMakeBookingException(EmployeeId employeeId)
        : base($"Cannot make a booking with an employee with id: {employeeId}")
    {
        EmployeeId = employeeId;
    }
}