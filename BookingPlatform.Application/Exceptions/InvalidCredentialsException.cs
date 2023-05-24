using BookingPlatform.Core.Exceptions;

namespace BookingPlatform.Application.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }
}