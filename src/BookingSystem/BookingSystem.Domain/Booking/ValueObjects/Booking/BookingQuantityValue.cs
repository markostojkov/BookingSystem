using BookingSystem.Common.Utils;
using BookingSystem.Domain.Common.ValueObjects;

namespace BookingSystem.Domain.Booking.ValueObjects
{
    public class BookingQuantityValue : QuantityValue
    {
        private const int maxQuantity = 100;

        private BookingQuantityValue(int bookingQuantity) : base(bookingQuantity)
        {
        }

        public static Result<BookingQuantityValue> Create(int quantity)
        {
            if (quantity > maxQuantity)
            {
                return Result.Invalid<BookingQuantityValue>(ResultErrorCodes.BookingQuantityValueExceeded);
            }

            return Result.Ok(new BookingQuantityValue(quantity));
        }
    }
}
