using CleanArchitecture.Common.Errors.Abstract;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Notifications.Order;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Aggregates;

public class Order:AggregateRoot<int>
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


    public Result ChangeDescription(string description)
    {
        //Validation
        if(string.IsNullOrEmpty(description))
            return Result.Failure(OrderErrors.EmptyDescription);

        //Raise Notification
        RaiseNotification(new DescriptionChangedForOrderNotification(OrderDescription, description,Id));

        OrderDescription = description;

        return Result.Success();
    }
    public void UpdateShippingAddress(string country, string city, string region, string street, string building, string floor, string apartment)
    {
        ShippingAddress = new ShippingAddress(country, city, region, street, building, floor, apartment);
    }

    public Result AddItem(string description, decimal unitPrice, decimal quantity)
    {
        //Validation
        var errors = new List<Error>();

        if(string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if(unitPrice<0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if(errors.Any())
            return Result.Failure(errors);

        var newOrderItem = new OrderItem(description, unitPrice, quantity, Id);
        _orderItems.Add(newOrderItem);

        //Raise Notification
        RaiseNotification(new ItemAddedToOrderNotification(newOrderItem.Id,Id));

        return Result.Success();
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity,List<Tax> taxes)
    {
        //Validation
        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (!taxes.Any())
            errors.Add(OrderItemErrors.EmptyTaxes);

        if (errors.Any())
            return Result.Failure(errors);

        var newOrderItem = new OrderItem(description, unitPrice, quantity, taxes, Id);

        _orderItems.Add(newOrderItem);

        //Raise Notification
        RaiseNotification(new ItemAddedToOrderNotification(newOrderItem.Id,Id));

        return Result.Success();
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue)
    {
        //Validation

        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (additionsValue < 0)
            errors.Add(OrderItemErrors.InvalidAdditionsValue);

        if (discountValue < 0)
            errors.Add(OrderItemErrors.InvalidDiscountValue);

        if (errors.Any())
            return Result.Failure(errors);

        var newOrderItem = new OrderItem(description, unitPrice, quantity, additionsValue, discountValue, Id);

        _orderItems.Add(newOrderItem);

        //Raise Notification
        RaiseNotification(new ItemAddedToOrderNotification(newOrderItem.Id, Id));

        return Result.Success();
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue,List<Tax> taxes)
    {
        //Validation

        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (additionsValue < 0)
            errors.Add(OrderItemErrors.InvalidAdditionsValue);

        if (discountValue < 0)
            errors.Add(OrderItemErrors.InvalidDiscountValue);

        if (!taxes.Any())
            errors.Add(OrderItemErrors.EmptyTaxes);

        if (errors.Any())
            return Result.Failure(errors);

        var newOrderItem = new OrderItem(description, unitPrice, quantity, additionsValue, discountValue, taxes, Id);

        _orderItems.Add(newOrderItem);

        //Raise Notification
        RaiseNotification(new ItemAddedToOrderNotification(newOrderItem.Id, Id));

        return Result.Success();
    }
    public void AddItem(OrderItem newItem)
    {
        _orderItems.Add(newItem);

        //Raise Notification
        RaiseNotification(new ItemAddedToOrderNotification(newItem.Id, Id));

    }


    public void RemoveItem(OrderItem removeItem)
    {
        var removedItemId = removeItem.Id;

        _orderItems.Remove(removeItem);

        //Raise Notification
        RaiseNotification(new ItemAddedToOrderNotification(removedItemId, Id));

    }


    #endregion
}