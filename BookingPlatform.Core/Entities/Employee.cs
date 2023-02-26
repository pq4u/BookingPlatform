using BookingPlatform.Core.Exceptions;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Entities;

public class Employee
{
    private readonly HashSet<Booking> _bookings = new();
    public EmployeeId Id { get; }
    public EmployeeName Name { get; }
    public IEnumerable<Booking> Bookings => _bookings;

    public Employee(EmployeeId id, EmployeeName name)
    {
        Id = id;
        Name = name;
    }

    public void AddBooking(Booking booking)
    {
        var isInvalidDate = booking.Date.Value < DateTime.UtcNow;

        if (isInvalidDate)
            throw new InvalidBookingDateException(booking.Date);

        _bookings.Add(booking);
    }
    
    public void RemoveBooking(BookingId id)
        => _bookings.RemoveWhere(x => x.Id == id);
}