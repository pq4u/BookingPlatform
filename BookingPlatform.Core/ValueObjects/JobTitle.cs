namespace BookingPlatform.Core.ValueObjects;

public sealed class JobTitle
{
    public string Value { get; }

    public const string Customer = nameof(Customer);
    public const string Boss = nameof(Boss);

    private JobTitle(string value)
        => Value = value;

    public static implicit operator string(JobTitle jobTitle)
        => jobTitle.Value;

    public static implicit operator JobTitle(string value)
        => new(value);
}