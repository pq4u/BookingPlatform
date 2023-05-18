using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Polices;

internal sealed class CustomerBookingPolicy : IBookingPolicy
{
    public bool CanBeApplied(JobTitle jobTitle)
        => jobTitle == JobTitle.Customer;

    public bool CanReserve(IEnumerable<Employee> employees, CustomerName customerName)
    {
        var totalCustomerBookings = employees
            .SelectMany(x => x.Bookings)
            .Count(x => x.CustomerName == customerName);

        return totalCustomerBookings <= 2;
    }
}