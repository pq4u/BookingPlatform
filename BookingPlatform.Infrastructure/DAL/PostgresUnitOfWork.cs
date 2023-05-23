﻿namespace BookingPlatform.Infrastructure.DAL;

internal class PostgresUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public PostgresUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}