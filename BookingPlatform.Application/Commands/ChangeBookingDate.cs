using BookingPlatform.Application.Abstractions;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Commands;

public record ChangeBookingDate(Guid BookingId, Date Date) : ICommand;