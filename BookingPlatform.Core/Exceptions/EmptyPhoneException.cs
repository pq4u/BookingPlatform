namespace BookingPlatform.Core.Exceptions;

public sealed class EmptyPhoneException : CustomException
{
    public EmptyPhoneException() : base("Phone number is empty.")
    {
    }
}