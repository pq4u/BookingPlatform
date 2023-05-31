using BookingPlatform.Application.Abstractions;
using BookingPlatform.Application.Commands;
using BookingPlatform.Application.DTO;
using BookingPlatform.Application.Queries;
using BookingPlatform.Core.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatform.Api.Controllers;

[ApiController]
[Route("bookings")]
public class BookingsController : ControllerBase
{
    private readonly ICommandHandler<CreateBookingForCustomer> _createBookingForCustomerHandler;
    private readonly ICommandHandler<ChangeBookingDate> _changeBookingDateHandler;
    private readonly ICommandHandler<DeleteBooking> _deleteBookingHandler;
    private readonly IQueryHandler<GetEmployees, IEnumerable<EmployeeDto>> _getEmployeesHandler;

    public BookingsController(IBookingService bookingsService, ICommandHandler<CreateBookingForCustomer> createBookingForCustomerHandler, ICommandHandler<ChangeBookingDate> changeBookingDate, ICommandHandler<DeleteBooking> deleteBooking, IQueryHandler<GetEmployees, IEnumerable<EmployeeDto>> getEmployeesHandler)
    {
        _createBookingForCustomerHandler = createBookingForCustomerHandler;
        _changeBookingDateHandler = changeBookingDate;
        _deleteBookingHandler = deleteBooking;
        _getEmployeesHandler = getEmployeesHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get([FromQuery] GetEmployees query)
        => Ok(await _getEmployeesHandler.HandleAsync(query));

    
    [Authorize]
    [HttpPost("{employeeId:guid}/bookings/")]
    public async Task<ActionResult> Post(Guid employeeId, CreateBookingForCustomer command)
    {
        await _createBookingForCustomerHandler.HandleAsync(command with
        {
            BookingId = Guid.NewGuid(),
            EmployeeId = employeeId,
            UserId = Guid.Parse(User.Identity.Name)
        });
        return NoContent();
    }

    [HttpPut("bookings/{bookingId:guid}")]
    public async Task<ActionResult> Put(Guid bookingId, ChangeBookingDate command)
    {
        await _changeBookingDateHandler.HandleAsync(command with { BookingId = bookingId });
        return NoContent();
    }

    [HttpDelete("bookings/{bookingId:guid}")]
    public async Task<ActionResult> Delete(Guid bookingId)
    {
        await _deleteBookingHandler.HandleAsync(new DeleteBooking(bookingId));
        
        return NoContent();
    }
}