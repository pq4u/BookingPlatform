namespace BookingPlatform.Application.DTO;

public class EmployeeDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<BookingDto> Bookings { get; set; }
}