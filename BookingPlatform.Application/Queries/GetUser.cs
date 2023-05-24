using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.DTO;

namespace BookingPlatform.Application.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; set; }
}