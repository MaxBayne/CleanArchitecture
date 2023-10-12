using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities;

public class OrderItem:Entity<int>
{
    #region Fields

    private readonly List<Tax> _itemTaxes;

    #endregion

    #region Properites

    public string Description { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal AdditionsValue { get; private set; }
    public decimal AdditionsPercent { get; private set; }

    public decimal TaxesValue { get; private set; }
    public decimal TaxesPercent { get; private set; }
   

    public decimal DiscountValue { get; private set; }
    public decimal DiscountPercent { get; private set; }


    /// <summary>
    /// الاجمالي قبل الخصم والاضافة والضرائب
    /// </summary>
    public decimal SubTotal => UnitPrice * Quantity;

    /// <summary>
    /// الاجمالي بعد الخصم والاضافة والضرائب
    /// </summary>
    public decimal Total => SubTotal + (AdditionsValue + (AdditionsPercent * SubTotal / 100)) + (TaxesValue + (TaxesPercent * SubTotal / 100)) - (DiscountValue - (DiscountPercent * SubTotal / 100));

    /// <summary>
    /// الضرائب المطبقة علي الصنف
    /// </summary>
    public IReadOnlyCollection<Tax> ItemTaxes => _itemTaxes;


    public int OrderId { get; private set; }

    #endregion

    #region Constructors

    public OrderItem(string description, decimal unitPrice, decimal quantity,int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        OrderId=orderId;

        _itemTaxes = new List<Tax>();
    }
    public OrderItem(string description, decimal unitPrice, decimal quantity,List<Tax>taxes, int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        OrderId = orderId;
        _itemTaxes = taxes;

        CalcTaxesValue();
        CalcTaxesPercent();
    }
    public OrderItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue, int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        AdditionsValue = additionsValue;
        DiscountValue = discountValue;
        OrderId = orderId;

        _itemTaxes = new List<Tax>();
        
    }
    public OrderItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue,List<Tax> taxes, int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        AdditionsValue = additionsValue;
        DiscountValue = discountValue;
        OrderId = orderId;
        _itemTaxes = taxes;

        CalcTaxesValue();
        CalcTaxesPercent();
    }

    #endregion

    #region Methods

    public Result ChangeDescription(string description)
    {
        //Validation
        if(string.IsNullOrEmpty(description))
            return Result.Failure(OrderItemErrors.EmptyDescription);

        Description = description;

        return Result.Success();
    }

    public Result ChangeUnitPrice(decimal unitPrice)
    {
        //Validation
        if (unitPrice < 0)
            return Result.Failure(OrderItemErrors.InvalidUnitPrice);

        UnitPrice = unitPrice;

        return Result.Success();
    }

    public Result UpdateQuantity(decimal quantity)
    {
        //Validation
        if (quantity <= 0)
            return Result.Failure(OrderItemErrors.InvalidQuantity);

        Quantity = quantity;

        return Result.Success();
    }

    public Result SetAdditionsValue(decimal additionsValue)
    {
        //Validation
        if (additionsValue <= 0)
            return Result.Failure(OrderItemErrors.InvalidAdditionsValue);

        AdditionsValue = additionsValue;

        return Result.Success();
    }

    public Result SetAdditionsPercent(decimal additionsPercent)
    {
        //Validation
        if (additionsPercent <= 0)
            return Result.Failure(OrderItemErrors.InvalidAdditionsPercent);


        AdditionsPercent = additionsPercent;

        return Result.Success();
    }

    public Result SetDiscountPercent(decimal discountPercent)
    {
        //Validation
        if (discountPercent <= 0)
            return Result.Failure(OrderItemErrors.InvalidDiscountPercent);

        DiscountPercent = discountPercent;

        return Result.Success();
    }

    public Result SetDiscountValue(decimal discountValue)
    {
        //Validation
        if (discountValue <= 0)
            return Result.Failure(OrderItemErrors.InvalidDiscountValue);

        DiscountValue = discountValue;

        return Result.Success();
    }




    public Result AddTaxValue(string taxName,decimal taxValue)
    {
        //Validation
        if(string.IsNullOrEmpty(taxName))
            return Result.Failure(TaxErrors.EmptyName);

        if(taxValue < 0)
            return Result.Failure(TaxErrors.InvalidTaxValue);


        _itemTaxes.Add(new Tax(taxName, taxValue,true,Id,OrderId));

        CalcTaxesValue();

        return Result.Success();
    }
    public Result AddTaxPercent(string taxName, decimal taxPercent)
    {
        //Validation
        if (string.IsNullOrEmpty(taxName))
            return Result.Failure(TaxErrors.EmptyName);

        if (taxPercent < 0)
            return Result.Failure(TaxErrors.InvalidTaxPercent);


        _itemTaxes.Add(new Tax(taxName, taxPercent,Id,OrderId));

        CalcTaxesPercent();

        return Result.Success();
    }

    public void RemoveTax(Tax tax)
    {
        _itemTaxes.Remove(tax);
    }

    public void ActiveTax(string taxName)
    {
        var findTax = _itemTaxes.FirstOrDefault(x => x.TaxName == taxName);

        if (findTax != null)
        {
            findTax.SetTaxActive();
        }
    }

    public void DeActiveTax(string taxName)
    {
        var findTax = _itemTaxes.FirstOrDefault(x => x.TaxName == taxName);

        if (findTax != null)
        {
            findTax.SetTaxDisActive();
        }
    }

    private void CalcTaxesValue()
    {
        TaxesValue= _itemTaxes.Sum(s => s.TaxValue);
    }

    private void CalcTaxesPercent()
    {
        TaxesPercent= _itemTaxes.Sum(s => s.TaxPercent);
    }

    #endregion
}