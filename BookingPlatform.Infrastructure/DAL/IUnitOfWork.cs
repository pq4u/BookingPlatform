namespace BookingPlatform.Infrastructure.DAL;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}