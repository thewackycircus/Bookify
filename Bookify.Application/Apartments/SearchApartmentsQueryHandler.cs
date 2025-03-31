using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Apartments.SearchApartments;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Apartments
{
    internal sealed class SearchApartmentsQueryHandler : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
    {
        private static readonly int[] ActiveBookingStatuses =
        {
            (int)BookingStatus.Reserved,
            (int)BookingStatus.Confirmed,
            (int)BookingStatus.Completed
        };

        private readonly ISqlConnectionFactory _sqlConnectiontionFactory;

        public SearchApartmentsQueryHandler(ISqlConnectionFactory sqlConnectiontionFactory)
        {
            _sqlConnectiontionFactory = sqlConnectiontionFactory;
        }

        public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentsQuery request, CancellationToken cancellationToken)
        {
            if (request.StartDate > request.EndDate) return new List<ApartmentResponse>();

            using var connection = _sqlConnectiontionFactory.CreateConnection();

            const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name,
                a.Description AS Description,
                a.PriceAmount AS Price,
                a.PriceCurrency AS Currency,
                a.AddressCountry AS Country,
                a.AddressState AS State,
                a.AddressZipCode AS ZipCode,
                a.AddressCity AS City,
                a.AddressStreet AS Street
            FROM Apartment AS a
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM Booking AS b
                WHERE
                    b.ApartmentId = a.id AND
                    b.DurationStart <= @EndDate AND
                    b.DurationEnd >= @StartDate AND
                    b.Status IN @ActiveBookingStatuses
            )
            """;

            var apartments = await connection.QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                sql,
                (apartment, address) =>
                {
                    apartment.Address = address;
                    return apartment;
                },
                new
                {
                    request.StartDate,
                    request.EndDate,
                    ActiveBookingStatuses
                },
                splitOn: "Country");

            return apartments.ToList();
        }
    }
}
