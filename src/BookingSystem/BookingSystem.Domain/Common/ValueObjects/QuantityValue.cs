namespace BookingSystem.Domain.Common.ValueObjects
{
    public class QuantityValue : BaseValueObject<QuantityValue>
    {
        protected QuantityValue(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }

        protected override bool EqualsCore(QuantityValue other)
        {
            return Quantity == other.Quantity;
        }

        protected override int GetHashCodeCore()
        {
            return Quantity.GetHashCode();
        }
    }
}
