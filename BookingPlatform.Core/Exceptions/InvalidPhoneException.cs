namespace BookingPlatform.Core.Exceptions;

public sealed class InvalidPhoneException : CustomException
{
    public string Phone { get; }
    public InvalidPhoneException(string phone) : base($"Phone: {phone} is invalid.")
    {
        Phone = phone;
    }
}