using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Configurations
{
    internal sealed class ApartmentConfiguration : BaseConfiguration, IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartment");
            builder.HasKey(apartment => apartment.Id);
            builder.OwnsOne(apartment => apartment.Address, builder => ConfigureAddress(builder, "Address"));
            builder.Property(apartment => apartment.Name)
                .HasMaxLength(200)
                .HasConversion(name => name.Value, value => new Name(value));
            builder.Property(apartment => apartment.Description)
                .HasMaxLength(2000)
                .HasConversion(description => description.Value, value => new Description(value));
            builder.OwnsOne(apartment => apartment.Price, builder => ConfigureMoney(builder, "Price"));
            builder.OwnsOne(apartment => apartment.CleaningFee, builder => ConfigureMoney(builder, "CleaningFee"));
            builder.Property<byte[]>("Version").IsRowVersion();
        }
    }
}
