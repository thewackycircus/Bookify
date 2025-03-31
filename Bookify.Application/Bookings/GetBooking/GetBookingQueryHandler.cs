using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.GetBooking
{
    internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
            SELECT
                Id AS Id,
                ApartmentId AS ApartmentId,
                UserId AS UserId,
                Status AS Status,
                PriceForPeriod_amount AS PriceAmount,
                PriceForPeriodCurrency AS PriceCurrency,
                CleaningFeeAmount AS CleaningFeeAmount,
                CleaningFeeCurrency AS CleaningFeeCurrency,
                AmenitiesUpChargeAmount AS AmenitiesUpChargeAmount,
                AmenitiesUpChargeCurrency AS AmenitiesUpChargeCurrency,
                TotalPriceAmount AS TotalPriceAmount,
                TotalPriceCurrency AS TotalPriceCurrency,
                DurationStart AS DurationStart,
                DurationEnd AS DurationEnd,
                CreatedOnUtc AS CreatedOnUtc
            FROM Booking
            WHERE Id = @BookingId
            """;

            var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
                sql,
                new
                {
                    request.BookingId
                });

            return booking;
        }
    }
}
