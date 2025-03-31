using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Apartments.SearchApartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Apartments
{
    public record SearchApartmentsQuery(
        DateOnly StartDate,
        DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
}
