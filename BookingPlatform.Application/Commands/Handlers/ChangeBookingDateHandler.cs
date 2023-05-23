using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.Exceptions;
using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Repositories;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Commands.Handlers;

public sealed class ChangeBookingDateHandler : ICommandHandler<ChangeBookingDate>
{
    private readonly IEmployeeRepository _repository;

    public ChangeBookingDateHandler(IEmployeeRepository repository)
        => _repository = repository;

    public async Task HandleAsync(ChangeBookingDate command)
    {
        var employee = await GetEmployeeByBooking(command.BookingId);
        if (employee is null)
            throw new EmployeeNotFoundException();

        var bookingId = new BookingId(command.BookingId);
        var booking = employee.Bookings.SingleOrDefault(x => x.Id == bookingId);

        if (booking is null)
            throw new BookingNotFoundException(command.BookingId);

        booking.ChangeDate(command.Date);
        await _repository.UpdateAsync(employee);
    }

    private async Task<Employee> GetEmployeeByBooking(BookingId id)
        => (await _repository.GetAllAsync())
            .SingleOrDefault(x => x.Bookings.Any(b => b.Id == id));
}