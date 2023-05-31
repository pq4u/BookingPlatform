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
    private IUserRepository _userRepository;

    public CreateBookingForCustomerHandler(IEmployeeRepository repository, IBookingService bookingService, IUserRepository userRepository)
    {
        _repository = repository;
        _bookingService = bookingService;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(CreateBookingForCustomer command)
    {
        var (bookingId, employeeId, userId, customerName, email, phone, date) = command;
        var employeeToBook = new EmployeeId(employeeId);
        var employees = (await _repository.GetAllAsync()).ToList();
        var employee = employees.SingleOrDefault(x => x.Id == employeeId);

        if (employee is null)
            throw new EmployeeNotFoundException(employeeToBook);

        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            throw new UserNotFoundException(userId);
        
        var booking = new Booking(bookingId, employeeId, user.Id, customerName, email,
            phone, new Date(date));

        _bookingService.BookForCustomer(employees, JobTitle.Customer, employee, booking);

        await _repository.UpdateAsync(employee);
    }
}