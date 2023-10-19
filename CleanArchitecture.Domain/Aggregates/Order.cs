using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Notifications.Order;
using CleanArchitecture.Domain.Notifications.OrderItem;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Aggregates;

public class Order : AggregateRoot<int>
{
    #region Fields

    private readonly List<OrderItem> _orderItems;


    #endregion

    #region Properites

    public string OrderNumber { get; private set; }
    public DateTime OrderDate { get; private set; }
    public string OrderDescription { get; private set; }
    public ShippingAddress ShippingAddress { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    #endregion

    #region Constructors

    public Order()
    {
        OrderNumber = string.Empty;
        OrderDate = DateTime.Now;
        OrderDescription = string.Empty;
        ShippingAddress = new ShippingAddress();
        _orderItems = new List<OrderItem>();
    }
    public Order(string orderNumber, DateTime orderDate, string orderDescription, ShippingAddress shippingAddress)
    {
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        OrderDescription = orderDescription;
        ShippingAddress = shippingAddress;
        _orderItems = new List<OrderItem>();
    }


    #endregion

    #region Methods

    #region Order

    public Result ChangeDescription(string description)
    {
        //Validation
        if (string.IsNullOrEmpty(description))
            return Result.Failure(OrderErrors.EmptyDescription);

        //Raise Notification
        RegisterNotification(new DescriptionChangedForOrderNotification(OrderDescription, description, Id));

        OrderDescription = description;

        return Result.Success();
    }
    public void UpdateShippingAddress(string country, string city, string region, string street, string building, string floor, string apartment)
    {
        ShippingAddress = new ShippingAddress(country, city, region, street, building, floor, apartment);
    }

    #endregion

    #region Order Items

    public Result AddItem(string description, decimal unitPrice, decimal quantity)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, Id);

        if (newOrderItem.IsSuccess)
        {
            _orderItems.Add(newOrderItem.Value!);
        }
        
        return Result.Failure(newOrderItem.Errors);
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, List<Tax> taxes)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, taxes, Id);

        if (newOrderItem.IsSuccess)
        {
            _orderItems.Add(newOrderItem.Value!);
        }

        return Result.Failure(newOrderItem.Errors);
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, additionsValue, discountValue, Id);

        if (newOrderItem.IsSuccess)
        {
            _orderItems.Add(newOrderItem.Value!);
        }

        return Result.Failure(newOrderItem.Errors);
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue, List<Tax> taxes)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, additionsValue, discountValue, taxes, Id);

        if (newOrderItem.IsSuccess)
        {
            _orderItems.Add(newOrderItem.Value!);
        }

        return Result.Failure(newOrderItem.Errors);
    }

    public Result UpdateItem(int orderItemId, string description, decimal unitPrice, decimal quantity)
    {
        var findItem = _orderItems.FirstOrDefault(c => c.Id == orderItemId);

        if (findItem is null)
            return Result.Failure(OrderItemErrors.NotFoundItemId);


        var updateResult = findItem.UpdateItem(description, unitPrice, quantity);


        return updateResult.IsSuccess ? Result.Success() : Result.Failure(updateResult.Errors);
    }

    public void RemoveItem(OrderItem removeItem)
    {
        //Raise Notification
        RegisterNotification(new OrderItemDeletedNotification(removeItem));

        _orderItems.Remove(removeItem);

    }

    #endregion

    #endregion
}