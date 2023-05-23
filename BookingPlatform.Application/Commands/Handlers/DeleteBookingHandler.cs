using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.Exceptions;
using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Repositories;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Commands.Handlers;

public class DeleteBookingHandler : ICommandHandler<DeleteBooking>
{
    private readonly IEmployeeRepository _repository;

    public DeleteBookingHandler(IEmployeeRepository repository) =>
        _repository = repository;

    public async Task HandleAsync(DeleteBooking command)
    {
        var employee = await GetEmployeeByBooking(command.BookingId);
        if (employee is null)
            throw new EmployeeNotFoundException();
        
        employee.RemoveBooking(command.BookingId);
        await _repository.UpdateAsync(employee);
    }

    private async Task<Employee> GetEmployeeByBooking(BookingId id)
        => (await _repository.GetAllAsync()).SingleOrDefault(x => x.Bookings.Any(b => b.Id == id));
}