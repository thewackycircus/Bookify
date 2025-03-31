using Bookify.Application.Abstractions.Clock;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.ReserveBooking
{
    public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        public ReserveBookingCommandValidator(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;

            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.ApartmentId).NotEmpty();
            RuleFor(c => c.StartDate).LessThan(c => c.EndDate).GreaterThanOrEqualTo(c => DateOnly.FromDateTime(_dateTimeProvider.UtcNow));
        }
    }
}
