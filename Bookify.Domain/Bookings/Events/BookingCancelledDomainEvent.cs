using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings
{
    public sealed record BookingCancelledDomainEvent(Guid bookingId) : IDomainEvent;
}