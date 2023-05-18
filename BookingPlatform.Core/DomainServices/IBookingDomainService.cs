using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.DomainServices;

public interface IBookingDomainService
{
    void BookForCustomer(IEnumerable<Employee> employees,
        JobTitle jobTitle, Employee employee, Booking booking);
}