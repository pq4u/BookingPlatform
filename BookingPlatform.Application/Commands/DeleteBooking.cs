using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Commands;

public record DeleteBooking(BookingId BookingId);