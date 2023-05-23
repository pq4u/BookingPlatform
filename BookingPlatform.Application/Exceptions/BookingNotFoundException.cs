using BookingPlatform.Core.Exceptions;

namespace BookingPlatform.Application.Exceptions;

public class BookingNotFoundException : CustomException
{
    public Guid Id { get; }
    public BookingNotFoundException(Guid id) : base($"Booking with ID: {id} was not found.")
    {
        Id = id;
    }
}