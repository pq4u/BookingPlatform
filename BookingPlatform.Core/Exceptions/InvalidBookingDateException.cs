using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Exceptions;

public sealed class InvalidBookingDateException : CustomException
{
    public Date Date { get; set; }
    public InvalidBookingDateException(Date date) : base($"Booking date is invalid: {date} ")
    {
        Date = date;
    }
}