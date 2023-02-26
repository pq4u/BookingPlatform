using BookingPlatform.Application.Commands;
using BookingPlatform.Application.DTO;

namespace BookingPlatform.Application.Services;

public interface IBookingService
{
    BookingDto Get(Guid id);
    IEnumerable<BookingDto> GetAll();
    Guid? Create(CreateBooking command);
    bool Delete(DeleteBooking command);
}