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
    public async Task<ActionResult<IEnumerable<BookingDto>>> Get()
        => Ok(_bookingsService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BookingDto>> Get(Guid id)
    {
        var booking = await _bookingsService.GetAsync(id);
        if (booking is null)
            return NotFound();

        return Ok(booking);
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateBooking command)
    {
        var id = await _bookingsService.CreateAsync(command with {BookingId = Guid.NewGuid()});
        if (id is null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        if (await _bookingsService.DeleteAsync(new DeleteBooking(id)))
            return NoContent();

        return NoContent();
    }
}