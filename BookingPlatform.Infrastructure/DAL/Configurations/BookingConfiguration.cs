using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingPlatform.Infrastructure.DAL.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new BookingId(x));
        builder.Property(x => x.EmployeeId)
            .HasConversion(x => x.Value, x => new EmployeeId(x));
        builder.Property(x => x.CustomerName)
            .HasConversion(x => x.Value, x => new CustomerName(x));
        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x));
        builder.Property(x => x.Phone)
            .HasConversion(x => x.Value, x => new Phone(x));
        builder.Property(x => x.Date)
            .HasConversion(x => x.Value, x => new Date(x));


    }
}