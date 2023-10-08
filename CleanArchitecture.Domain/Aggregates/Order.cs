using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ObjectValues;

namespace CleanArchitecture.Domain.Aggregates;

public class Order:BaseAggregateRoot<int>
{
    #region Fields

    private readonly List<OrderItem> _orderItems = new List<OrderItem>();


    #endregion

    #region Properites

    public string OrderNumber { get; private set; } = null!;
    public DateTime OrderDate { get; private set; }
    public string OrderDescription { get; private set; } = null!;
    public ShippingAddress ShippingAddress { get; private set; } = null!;

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    #endregion

    #region Constructors

    public Order() { }
    public Order(string orderNumber, DateTime orderDate, string orderDescription,ShippingAddress shippingAddress)
    {
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        OrderDescription = orderDescription;
        ShippingAddress = shippingAddress;
    }


    #endregion

    #region Methods


    public void ChangeDescription(string description)
    {
        OrderDescription = description;
    }
    public void UpdateShippingAddress(string country, string city, string region, string street, string building, string floor, string apartment)
    {
        ShippingAddress = new ShippingAddress(country, city, region, street, building, floor, apartment);
    }

    public void AddItem(string description, decimal unitPrice, decimal quantity)
    {
        _orderItems.Add(new OrderItem(description, unitPrice, quantity));
    }
    public void AddItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal taxValue, decimal discountValue)
    {
        _orderItems.Add(new OrderItem(description, unitPrice, quantity,additionsValue,taxValue,discountValue));
    }
    public void AddItem(OrderItem item)
    {
        _orderItems.Add(item);
    }


    public void RemoveItem(OrderItem item)
    {
        _orderItems.Remove(item);
    }
    

    #endregion
}