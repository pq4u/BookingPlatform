using BookingPlatform.Application.Abstractions;

namespace BookingPlatform.Application.Commands;

public record SignIn(string Email, string Password) : ICommand;