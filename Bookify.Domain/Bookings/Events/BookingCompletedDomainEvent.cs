﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings
{
    public sealed record BookingCompletedDomainEvent(Guid bookingId) : IDomainEvent;
}