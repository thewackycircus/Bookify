﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings
{
    public sealed record BookingConfirmedDomainEvent(Guid bookingId) : IDomainEvent;
}