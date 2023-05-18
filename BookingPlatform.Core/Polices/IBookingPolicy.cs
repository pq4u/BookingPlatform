using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Polices;

public interface IBookingPolicy
{
    bool CanBeApplied(JobTitle jobTitle);
    bool CanReserve(IEnumerable<Employee> employees, CustomerName customerName);
}