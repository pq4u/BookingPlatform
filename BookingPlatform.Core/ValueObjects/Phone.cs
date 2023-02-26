using BookingPlatform.Core.Exceptions;

namespace BookingPlatform.Core.ValueObjects;

public sealed record Phone
{
    public string Value { get; }

    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyPhoneException();

        if (value.Length != 9)
            throw new InvalidPhoneException(value);

        Value = value;
    }

    public static implicit operator string(Phone phone) => phone.Value;

    public static implicit operator Phone(string phone) => new(phone);
        
    public override string ToString() => Value;
}