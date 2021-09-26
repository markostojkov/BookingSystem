using BookingSystem.Common.Utils;
using BookingSystem.Domain.Booking.ValueObjects;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Common.ValueObjects;
using System;

namespace BookingSystem.Domain.Booking
{
    public class Booking : IntervalComparableEntity
    {
        private Booking(BookingQuantityValue bookingQuantity, IntervalValue bookingDate) : base(bookingDate, bookingQuantity)
        {
            Uid = Guid.NewGuid();
            BookingQuantity = bookingQuantity;
        }

        private Booking(Guid uid, BookingQuantityValue bookingQuantity, IntervalValue bookingDate) : base(bookingDate, bookingQuantity)
        {
            Uid = uid;
            BookingQuantity = bookingQuantity;
        }

        public BookingQuantityValue BookingQuantity { get; }

        public static Result<Booking> Create(DateTime startDate, DateTime endDate, int quantity)
        {
            var dateValue = IntervalValue.Create(startDate, endDate);
            var quantityValue = BookingQuantityValue.Create(quantity);

            var successOrError = Result.FirstFailureOrOk(dateValue, quantityValue);

            if (successOrError.IsFailure)
            {
                return Result.FromError<Booking>(successOrError);
            }

            return Result.Ok(new Booking(quantityValue.Value, dateValue.Value));
        }

        public static Result<Booking> Create(Guid uid, DateTime startDate, DateTime endDate, int quantity)
        {
            var dateValue = IntervalValue.CreateExisting(startDate, endDate);
            var quantityValue = BookingQuantityValue.Create(quantity);

            var successOrError = Result.FirstFailureOrOk(dateValue, quantityValue);

            if (successOrError.IsFailure)
            {
                return Result.FromError<Booking>(successOrError);
            }

            return Result.Ok(new Booking(uid, quantityValue.Value, dateValue.Value));
        }
    }
}
