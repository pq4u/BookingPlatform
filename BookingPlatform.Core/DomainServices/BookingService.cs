using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Exceptions;
using BookingPlatform.Core.Polices;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.DomainServices;

public class BookingService : IBookingService
{
    private readonly IEnumerable<IBookingPolicy> _policies;

    public BookingService(IEnumerable<IBookingPolicy> policies)
    {
        _policies = policies;
    }
    
    public void BookForCustomer(IEnumerable<Employee> employees,
        JobTitle jobTitle,
        Employee employee,
        Booking booking)
    {
        var employeeId = employee.Id;
        var policy = _policies.FirstOrDefault(x => x.CanBeApplied(jobTitle));

        if (policy is null)
            throw new NoBookingPolicyFoundException(jobTitle);

        if (!policy.CanReserve(employees, booking.CustomerName))
            throw new CannotMakeBookingException(employeeId);
        
        employee.AddBooking(booking);
    }
}