﻿using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings
{
    public sealed class Booking : Entity
    {
        private Booking (
            Guid id, 
            Apartment apartment, 
            Guid userId, 
            DateRange duration, 
            Money priceForPeriod, 
            Money cleaningFee,
            Money amenitiesUpCharge,
            Money totalPrice,
            BookingStatus status,
            DateTime createdOnUtc
            )
            : base(id)
        {
            ApartmentId = apartment.Id;
            UserId = userId;
            Duration = duration;
            PriceForPeriod = priceForPeriod;
            CleaningFee = cleaningFee;
            AmenitiesUpCharge = amenitiesUpCharge;
            TotalPrice = totalPrice;
            Status = status;
            CreatedOnUtc = createdOnUtc;
        }

        private Booking() { }

        public Guid ApartmentId { get; private set; }
        public Guid UserId {  get; private set; }
        public DateRange Duration {  get; private set; }
        public Money PriceForPeriod {  get; private set; }
        public Money CleaningFee {  get; private set; }
        public Money AmenitiesUpCharge { get; private set; }
        public Money TotalPrice {  get; private set; }
        public BookingStatus Status {  get; private set; }
        public DateTime CreatedOnUtc {  get; private set; }
        public DateTime ConfirmedOnUtc {  get; private set; }
        public DateTime RejectedOnUtc {  get; private set; }
        public DateTime CompletedOnUtc {  get; private set; }
        public DateTime CancelledOnUtc {  get; private set; }

        public static Booking Reserve(
            Apartment apartment, 
            Guid userId, 
            DateRange duration, 
            DateTime utcNow, 
            PricingService pricingService)
        {
            var pricingDetails = pricingService.CalculatePrice(apartment, duration);

            var booking = new Booking(
                Guid.NewGuid(), 
                apartment, 
                userId, 
                duration, 
                pricingDetails.PriceForPeriod, 
                pricingDetails.CleaningFee,
                pricingDetails.AmenitiesUpCharge,
                pricingDetails.TotalPrice,
                BookingStatus.Reserved,
                utcNow);

            booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

            apartment.LastBookedOnUtc = utcNow;

            return booking;
        }

        public Result Confirm(DateTime utcNow)
        {
            if (Status != BookingStatus.Reserved) return Result.Failure(BookingErrors.NotPending);

            Status = BookingStatus.Confirmed;
            ConfirmedOnUtc = utcNow;

            RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));

            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != BookingStatus.Reserved) return Result.Failure(BookingErrors.NotPending);

            Status = BookingStatus.Rejected;
            RejectedOnUtc = utcNow;

            RaiseDomainEvent(new BookingRejectedDomainEvent(Id));

            return Result.Success();
        }

        public Result Complete(DateTime utcNow)
        {
            if (Status != BookingStatus.Reserved) return Result.Failure(BookingErrors.NotPending);

            Status = BookingStatus.Completed;
            CompletedOnUtc = utcNow;

            RaiseDomainEvent(new BookingCompletedDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status != BookingStatus.Reserved) return Result.Failure(BookingErrors.NotPending);

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.Start) return Result.Failure(BookingErrors.AlreadyStarted);

            Status = BookingStatus.Cancelled;
            CancelledOnUtc = utcNow;

            RaiseDomainEvent(new BookingCancelledDomainEvent(Id));

            return Result.Success();
        }
    }
}
