using BookingPlatform.Core.Entities;
using BookingPlatform.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingPlatform.Infrastructure.DAL.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EmployeeId(x));
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => new EmployeeName(x));
    }
}