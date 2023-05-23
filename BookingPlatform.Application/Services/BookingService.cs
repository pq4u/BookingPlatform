using BookingPlatform.Application.Commands;
using BookingPlatform.Application.DTO;
using BookingPlatform.Core.DomainServices;
using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Repositories;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Services;
/*
public class BookingService : IBookingService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IBookingDomainService _bookingDomainService;

    public BookingService(IEmployeeRepository employeeRepository, IBookingDomainService bookingDomainService)
    {
        _employeeRepository = employeeRepository;
        _bookingDomainService = bookingDomainService;
    }

    public async Task<BookingDto> GetAsync(Guid id)
    {
        var employees = await GetAllAsync();
        return employees.SingleOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        
        return employees
            .SelectMany(x => x.Bookings)
            .Select(x => new BookingDto()
            {
                Id = x.Id,
                EmployeeId = x.EmployeeId,
                CustomerName = x.CustomerName,
                Email = x.Email,
                Phone = x.Phone,
                Date = x.Date.Value.Date
            });
    }
    

    public async Task<Guid?> CreateAsync(CreateBooking command)
    {
        //var employee = _employeeRepository.GetAll().SingleOrDefault(x => x.Id == command.EmployeeId);
        var employeeId = new EmployeeId(command.EmployeeId);
        var employees = (await _employeeRepository.GetAllAsync()).ToList();
        var employee = employees.SingleOrDefault(x => x.Id == employeeId);
        if (employee is null)
            return default;

        var booking = new Booking(command.BookingId, command.EmployeeId,
            command.CustomerName, command.Email, command.Phone, new Date(command.Date));

        //employee.AddBooking(booking);
        _bookingDomainService.BookForCustomer(employees, JobTitle.Customer, employee, booking);
        await _employeeRepository.UpdateAsync(employee);
        return booking.Id;
    }

    public async Task<bool> DeleteAsync(DeleteBooking command)
    {
        var employee = await GetEmployeeByBookingAsync(command.BookingId);
        if (employee is null)
            return false;

        var existingBooking = employee.Bookings.SingleOrDefault(x => x.Id == command.BookingId);
        if (existingBooking is null)
            return false;

        employee.RemoveBooking(command.BookingId);
        _employeeRepository.UpdateAsync(employee);
        return true;
    }

    private async Task<Employee> GetEmployeeByBookingAsync(BookingId bookingId)
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.SingleOrDefault(x => x.Bookings.Any(r => r.Id == bookingId));
    }
}*/