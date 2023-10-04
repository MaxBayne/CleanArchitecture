namespace CleanArchitecture.Domain.Abstract
{
    public abstract class BaseObjectValue
    {

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;

            if (obj.GetType() != GetType()) return false;

            return ReferenceEquals(this, obj);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

        public static bool operator ==(BaseObjectValue obj1, BaseObjectValue obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(BaseObjectValue obj1, BaseObjectValue obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
