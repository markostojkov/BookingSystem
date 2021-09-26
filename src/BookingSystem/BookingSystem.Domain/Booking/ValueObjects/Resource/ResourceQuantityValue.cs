using BookingSystem.Common.Utils;
using BookingSystem.Domain.Common.ValueObjects;

namespace BookingSystem.Domain.Booking.ValueObjects
{
    public class ResourceQuantityValue : QuantityValue
    {
        private const int maxValue = 100;

        private ResourceQuantityValue(int resourceQuantity) : base(resourceQuantity)
        {
        }

        public int ResourceQuantity { get; }

        public static Result<ResourceQuantityValue> Create(int quantity)
        {
            if (quantity > maxValue)
            {
                return Result.Invalid<ResourceQuantityValue>(ResultErrorCodes.ResourceQuantityValueExceeded);
            }

            return Result.Ok(new ResourceQuantityValue(quantity));
        }
    }
}
