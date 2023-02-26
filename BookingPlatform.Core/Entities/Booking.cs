using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Core.Entities;

public class Booking
{
    public BookingId Id { get; set; }
    public EmployeeId EmployeeId { get; private set; }
    public CustomerName CustomerName { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public Date Date { get; private set; }

    public Booking(BookingId id, EmployeeId employeeId, CustomerName customerName, Email email, Phone phone, Date date)
    {
        Id = id;
        EmployeeId = employeeId;
        CustomerName = customerName;
        Email = email;
        Phone = phone;
        Date = date;
    }
}