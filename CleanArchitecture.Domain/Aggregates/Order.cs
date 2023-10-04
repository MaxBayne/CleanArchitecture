using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Aggregates;

public class Order:BaseAggregateRoot<int>
{
    public DateTime OrderDate { get; private set; }

    
}