using BookingPlatform.Application.DTO;
using BookingPlatform.Core.Entities;

namespace BookingPlatform.Infrastructure.Handlers;

internal static class Extensions
{
    public static EmployeeDto AsDto(this Employee entity)
        => new()
        {
            Id = entity.Id.Value.ToString(),
            Name = entity.Name,
            Bookings = entity.Bookings.Select(x => new BookingDto
            {
                Id = x.Id,
                EmployeeId = x.EmployeeId,
                CustomerName = x.CustomerName,
                Email = x.Email,
                Phone = x.Phone,
                Date = x.Date.Value.Date
            })
        };

    public static UserDto AsDto(this User entity)
        => new()
        {
            Id = entity.Id,
            Username = entity.Username,
            FullName = entity.FullName
        };
}