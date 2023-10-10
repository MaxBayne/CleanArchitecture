namespace CleanArchitecture.Domain.Abstract
{
    /// <summary>
    /// Any thing not have Id
    /// </summary>
    public abstract class ValueObject
    {

        #region Equality

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

        public static bool operator ==(ValueObject obj1, ValueObject obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(ValueObject obj1, ValueObject obj2)
        {
            return !(obj1 == obj2);
        }

        #endregion

    }
}
