using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.DTO;

public class BookingDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Date { get; set; }
}