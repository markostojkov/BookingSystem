namespace BookingSystem.Domain.Common
{
    public abstract class BaseValueObject<T> where T : BaseValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (valueObject is null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(BaseValueObject<T> a, BaseValueObject<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseValueObject<T> a, BaseValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
