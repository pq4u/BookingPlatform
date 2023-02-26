namespace BookingPlatform.Core.Exceptions;

public sealed class EmptyEmailException : CustomException
{
    public EmptyEmailException() : base("Email is empty.")
    {
    }
}