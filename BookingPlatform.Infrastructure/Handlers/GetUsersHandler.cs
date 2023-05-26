using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.DTO;
using BookingPlatform.Application.Queries;
using BookingPlatform.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Infrastructure.Handlers;

public class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetUsersHandler(ApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();
}