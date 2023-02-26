using BookingPlatform.Core.Exceptions;

namespace BookingPlatform.Core.ValueObjects;

public sealed record CustomerName(string Value)
{
    public string Value { get; } = Value ?? throw new InvalidEmployeeNameException();

    public static implicit operator string(CustomerName name)
        => name.Value;
    
    public static implicit operator CustomerName(string value)
        => new(value);
}