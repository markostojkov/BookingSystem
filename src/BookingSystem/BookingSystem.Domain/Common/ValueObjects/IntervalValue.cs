using BookingSystem.Common.Utils;
using System;

namespace BookingSystem.Domain.Common.ValueObjects
{
    public class IntervalValue : BaseValueObject<IntervalValue>
    {
        private IntervalValue(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public static Result<IntervalValue> Create(DateTime startDate, DateTime endDate)
        {
            if (startDate < DateTime.UtcNow)
            {
                return Result.Invalid<IntervalValue>(ResultErrorCodes.IntervalStartDateInvalid);
            }

            if (endDate < DateTime.UtcNow)
            {
                return Result.Invalid<IntervalValue>(ResultErrorCodes.IntervalEndDateInvalid);
            }

            if (startDate >= endDate)
            {
                return Result.Invalid<IntervalValue>(ResultErrorCodes.IntervalStartDateMustBeBeforeEndDate);
            }

            return Result.Ok(new IntervalValue(startDate, endDate));
        }

        public static Result<IntervalValue> CreateExisting(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                return Result.Invalid<IntervalValue>(ResultErrorCodes.IntervalStartDateMustBeBeforeEndDate);
            }

            return Result.Ok(new IntervalValue(startDate, endDate));
        }

        protected override bool EqualsCore(IntervalValue other)
        {
            return StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = StartDate.GetHashCode();
                hashCode = (hashCode * 397) ^ EndDate.GetHashCode();
                return hashCode;
            }
        }
    }
}
