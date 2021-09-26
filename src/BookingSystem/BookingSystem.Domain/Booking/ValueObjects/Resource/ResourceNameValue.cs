using BookingSystem.Common.Utils;
using BookingSystem.Domain.Common;

namespace BookingSystem.Domain.Booking.ValueObjects
{
    public class ResourceNameValue : BaseValueObject<ResourceNameValue>
    {
        private const int maxLength = 100;

        private ResourceNameValue(string resourceName)
        {
            ResourceName = resourceName;
        }

        public string ResourceName { get; }

        public static Result<ResourceNameValue> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Invalid<ResourceNameValue>(ResultErrorCodes.ResourceNameValueCantBeNull);
            }

            if (name.Length > maxLength)
            {
                return Result.Invalid<ResourceNameValue>(ResultErrorCodes.ResourceNameValueExceeded);
            }

            return Result.Ok(new ResourceNameValue(name));
        }

        protected override bool EqualsCore(ResourceNameValue other)
        {
            return ResourceName == other.ResourceName;
        }

        protected override int GetHashCodeCore()
        {
            int hashCode = ResourceName.GetHashCode();
            return hashCode;
        }
    }
}
