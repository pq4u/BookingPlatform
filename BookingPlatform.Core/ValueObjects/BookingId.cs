using BookingPlatform.Core.Exceptions;

namespace BookingPlatform.Core.ValueObjects;

public sealed record BookingId
{
    public Guid Value { get; }

    public BookingId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static BookingId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(BookingId date)
        => date.Value;

    public static implicit operator BookingId(Guid value)
        => new(value);
}