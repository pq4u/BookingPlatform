using BookingPlatform.Application.Commands;
using BookingPlatform.Application.DTO;
using BookingPlatform.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatform.Api.Controllers;

[ApiController]
[Route("bookings")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingsService;

    public BookingsController(IBookingService bookingsService)
    {
        _bookingsService = bookingsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BookingDto>> Get() => Ok(_bookingsService.GetAll());

    [HttpGet("{id:guid}")]
    public ActionResult<BookingDto> Get(Guid id)
    {
        var booking = _bookingsService.Get(id);
        if (booking is null)
            return NotFound();

        return Ok(booking);
    }

    [HttpPost]
    public ActionResult Post(CreateBooking command)
    {
        var id = _bookingsService.Create(command with {BookingId = Guid.NewGuid()});
        if (id is null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        if (_bookingsService.Delete(new DeleteBooking(id)))
            return NoContent();

        return NoContent();
    }
}