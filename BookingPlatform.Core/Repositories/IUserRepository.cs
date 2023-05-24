using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(UserId id);
    Task<User> GetByEmailAsync(Email email);
    Task<User> GetByUsernameAsync(Username username);
    Task AddAsync(User user);
}