using BookingPlatform.Core.Entities;
using BookingPlatform.Core.Exceptions;
using BookingPlatform.Core.ValueObjects;
using Shouldly;
using Xunit;

namespace BookingPlatform.Tests.Unit.Entities;

public class EmployeeTests
{
    [Theory]
    [InlineData("2022-07-06")]
    public void given_invalid_date_add_booking_should_fail(string dateString)
    {
        var invalidDate = DateTime.Parse(dateString);

        var booking = new Booking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Jack Norris", "emia@mds.pl", "123123123", new Date(invalidDate));

        var exception = Record.Exception(() => _employee.AddBooking(booking));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidBookingDateException>();
    }

    [Fact]
    public void given_valid_date_add_booking_should_succeed()
    {
        var bookingDate = _now.AddDays(1);
        var booking = new Booking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Joe Allison", "email@em.pl", "123123123", bookingDate);

        _employee.AddBooking(booking);

        _employee.Bookings.ShouldHaveSingleItem();
        _employee.Bookings.ShouldContain(booking);
    }
    
    #region ARRANGE
    
    private readonly Employee _employee;
    private readonly Date _now;

    public EmployeeTests()
    {
        _now = new Date(DateTime.UtcNow);
        _employee = Employee.Create(Guid.NewGuid(), "Claire Williams");
    }
    
    #endregion
}