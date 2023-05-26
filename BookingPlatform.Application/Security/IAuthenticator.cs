using BookingPlatform.Application.DTO;

namespace BookingPlatform.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}