using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Commands;

public record CreateBooking(BookingId BookingId, EmployeeId EmployeeId, CustomerName CustomerName, Email Email, Phone Phone, Date Date);