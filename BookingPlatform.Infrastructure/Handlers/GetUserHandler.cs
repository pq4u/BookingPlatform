using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.DTO;
using BookingPlatform.Application.Queries;
using BookingPlatform.Core.ValueObjects;
using BookingPlatform.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Infrastructure.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly ApplicationDbContext _dbContext;

    public GetUserHandler(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<UserDto> HandleAsync(GetUser query)
    {
        var userId = new UserId(query.UserId);
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == userId);

        return user?.AsDto();
    }
}