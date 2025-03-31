using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Shared;
using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations;

internal sealed class BookingConfiguration : BaseConfiguration, IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");
        builder.HasKey(booking => booking.Id);
        builder.OwnsOne(booking => booking.PriceForPeriod, builder => ConfigureMoney(builder, "PriceForPeriod"));
        builder.OwnsOne(booking => booking.CleaningFee, builder => ConfigureMoney(builder, "CleaningFee"));
        builder.OwnsOne(booking => booking.AmenitiesUpCharge, builder => ConfigureMoney(builder, "AmenitiesUpCharge"));
        builder.OwnsOne(booking => booking.TotalPrice, builder => ConfigureMoney(builder, "TotalPrice"));
        builder.OwnsOne(booking => booking.Duration, builder => ConfigureDateRange(builder, "Duration"));
        builder.HasOne<Apartment>()
            .WithMany()
            .HasForeignKey(booking => booking.ApartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(booking => booking.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}