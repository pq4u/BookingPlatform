using BookingPlatform.Application.DTO;

namespace BookingPlatform.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}