using BookingSystem.Common.Utils;
using BookingSystem.Domain.Common.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Domain.Common
{
    public abstract class IntervalComparableEntity : Entity
    {
        protected IntervalComparableEntity(IntervalValue intervalValue, QuantityValue quantityValue)
        {
            IntervalValue = intervalValue;
            QuantityValue = quantityValue;
        }

        public IntervalValue IntervalValue { get; }
        public QuantityValue QuantityValue { get; set; }

        public Result EntityInValidInterval(IEnumerable<IntervalComparableEntity> comparableEntities, QuantityValue quantityValue)
        {
            if (comparableEntities.Any())
            {
                var entitiesInInterval = comparableEntities.Where(x => IntervalValue.StartDate < x.IntervalValue.EndDate && IntervalValue.EndDate > x.IntervalValue.StartDate);

                if (entitiesInInterval.Select(x => x.QuantityValue.Quantity).Sum() + QuantityValue.Quantity > quantityValue.Quantity)
                {
                    return Result.Conflicted(ResultErrorCodes.BookingQuantityValueExceeded);
                }

            }

            return Result.Ok();
        }
    }
}
