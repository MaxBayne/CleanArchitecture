namespace CleanArchitecture.Domain.Abstract;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; } = default!;

    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get;private set; }

    public int CreatedBy {get;private set;}
    public int UpdatedBy { get;private set; }

        
    public override bool Equals(object? obj)
    {
        if(ReferenceEquals(obj, null)) return false;

        if (ReferenceEquals(this, obj)) return true;

        if(obj is not BaseEntity<TId>) return false;

        if (obj.GetType() != GetType()) return false;

        var other = obj as BaseEntity<TId>;
            
        if (Id == null || other!.Id == null) return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
        return Id != null ? Id.GetHashCode() : base.GetHashCode();
    }

    public static bool operator ==(BaseEntity<TId>? obj1, BaseEntity<TId>? obj2)
    {
        return obj1?.Equals(obj2) ?? ReferenceEquals(obj2, null);
    }

    public static bool operator !=(BaseEntity<TId>? obj1, BaseEntity<TId>? obj2)
    {
        return !(obj1 == obj2);
    }
}