﻿using BookingPlatform.Application.Abstractions;
using BookingPlatform.Core.ValueObjects;

namespace BookingPlatform.Application.Commands;

public record CreateBookingForCustomer(BookingId BookingId,
    EmployeeId EmployeeId, UserId UserId, CustomerName CustomerName,
    Email Email, Phone Phone, Date Date) : ICommand;