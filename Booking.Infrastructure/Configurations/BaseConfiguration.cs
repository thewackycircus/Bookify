using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Configurations
{
    internal class BaseConfiguration
    {
        protected static void ConfigureMoney<T>(OwnedNavigationBuilder<T, Money> builder, string prefix)
            where T : Entity
        {
            builder.Property(m => m.Amount)
                .HasPrecision(18, 4)
                .HasColumnName($"{prefix}Amount"); ;
            builder.Property(m => m.Currency)
                .HasConversion(c => c.Code, code => Currency.FromCode(code))
                .HasColumnName($"{prefix}Currency");
        }

        protected static void ConfigureAddress<T>(OwnedNavigationBuilder<T, Address> builder, string prefix)
            where T : Entity
        {
            builder.Property(a => a.Country)
                .IsRequired()
                .HasColumnName($"{prefix}Country");
            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnName($"{prefix}State");
            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasColumnName($"{prefix}ZipCode");
            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnName($"{prefix}City");
            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnName($"{prefix}Street");
        }

        protected static void ConfigureDateRange<T>(OwnedNavigationBuilder<T, DateRange> builder, string prefix)
            where T : Entity
        {
            builder.Property(d => d.Start)
                .HasColumnName($"{prefix}Start"); 
            builder.Property(d => d.End)
                .HasColumnName($"{prefix}End");
        }
    }
}
