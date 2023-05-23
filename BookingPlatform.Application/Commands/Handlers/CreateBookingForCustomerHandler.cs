using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.Exceptions;
using BookingPlatform.Application.Services;
using BookingPlatform.Core.DomainServices;
using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Repositories;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Commands.Handlers;

public class CreateBookingForCustomerHandler : ICommandHandler<CreateBookingForCustomer>
{
    private readonly IEmployeeRepository _repository;
    private IBookingService _bookingService;

    public CreateBookingForCustomerHandler(IEmployeeRepository repository, IBookingService bookingService)
    {
        _repository = repository;
        _bookingService = bookingService;
    }

    public async Task HandleAsync(CreateBookingForCustomer command)
    {
        var (bookingId, employeeId, customerName, email, phone, date) = command;
        var employeeToBook = new EmployeeId(employeeId);
        var employees = (await _repository.GetAllAsync()).ToList();
        var employee = employees.SingleOrDefault(x => x.Id == employeeId);

        if (employee is null)
            throw new EmployeeNotFoundException(employeeToBook);

        var booking = new Booking(bookingId, employeeId, customerName, email,
            phone, new Date(date));

        _bookingService.BookForCustomer(employees, JobTitle.Customer, employee, booking);

        await _repository.UpdateAsync(employee);
    }
}