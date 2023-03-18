using BookingPlatform.Application.Commands;
using BookingPlatform.Application.DTO;

namespace BookingPlatform.Application.Services;

public interface IBookingService
{
    Task<BookingDto> GetAsync(Guid id);
    Task<IEnumerable<BookingDto>> GetAllAsync();
    Task<Guid?> CreateAsync(CreateBooking command);
    Task<bool> DeleteAsync(DeleteBooking command);
}