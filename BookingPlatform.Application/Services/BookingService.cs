using BookingPlatform.Application.Commands;
using BookingPlatform.Application.DTO;
using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Repositories;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Services;

public class BookingService : IBookingService
{
    private readonly IEmployeeRepository _employeeRepository;

    public BookingService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public BookingDto Get(Guid id)
        => GetAll().SingleOrDefault(x => x.Id == id);

    public IEnumerable<BookingDto> GetAll()
        => _employeeRepository.GetAll().SelectMany(x => x.Bookings)
            .Select(x => new BookingDto()
            {
                Id = x.Id,
                EmployeeId = x.EmployeeId,
                CustomerName = x.CustomerName,
                Email = x.Email,
                Phone = x.Phone,
                Date = x.Date.Value.Date
            });

    public Guid? Create(CreateBooking command)
    {
        //var employee = _employeeRepository.GetAll().SingleOrDefault(x => x.Id == command.EmployeeId);
        var employeeId = new EmployeeId(command.EmployeeId);
        var employee = _employeeRepository.Get(employeeId);
        if (employee is null)
            return default;

        var booking = new Booking(command.BookingId, command.EmployeeId,
            command.CustomerName, command.Email, command.Phone, new Date(command.Date));

        employee.AddBooking(booking);
        _employeeRepository.Update(employee);
        return booking.Id;
    }

    public bool Delete(DeleteBooking command)
    {
        var employee = GetEmployeeByBooking(command.BookingId);
        if (employee is null)
            return false;

        var existingBooking = employee.Bookings.SingleOrDefault(x => x.Id == command.BookingId);
        if (existingBooking is null)
            return false;

        employee.RemoveBooking(command.BookingId);
        _employeeRepository.Update(employee);
        return true;
    }

    private Employee GetEmployeeByBooking(BookingId bookingId)
        => _employeeRepository.GetAll().SingleOrDefault(x => x.Bookings.Any(b => b.Id == bookingId));
}