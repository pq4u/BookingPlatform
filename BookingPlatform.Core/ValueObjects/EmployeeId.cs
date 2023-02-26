using BookingPlatform.Core.Exceptions;

namespace BookingPlatform.Core.ValueObjects;

public sealed record EmployeeId
{
    public Guid Value { get; }

    public EmployeeId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static EmployeeId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(EmployeeId date)
        => date.Value;

    public static implicit operator EmployeeId(Guid value)
        => new(value);

    public override string ToString()
        => Value.ToString("N");
}