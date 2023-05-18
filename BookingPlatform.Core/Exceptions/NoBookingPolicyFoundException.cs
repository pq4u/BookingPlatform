using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Exceptions;

public sealed class NoBookingPolicyFoundException : CustomException
{
    public JobTitle JobTitle { get; }
    public NoBookingPolicyFoundException(JobTitle jobTitle)
        : base($"No booking policy for {jobTitle} has been found")
    {
        JobTitle = jobTitle;
    }
}