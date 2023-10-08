using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities;

public class OrderItem:BaseEntity<int>
{
    #region Properites

    public string Description { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal AdditionsValue { get; private set; }
    public decimal AdditionsPercent { get; private set; }

    public decimal TaxValue { get; private set; }
    public decimal TaxPercent { get; private set; }


    public decimal DiscountValue { get; private set; }
    public decimal DiscountPercent { get; private set; }


    /// <summary>
    /// الاجمالي قبل الخصم والاضافة والضرائب
    /// </summary>
    public decimal SubTotal => UnitPrice * Quantity;

    /// <summary>
    /// الاجمالي بعد الخصم والاضافة والضرائب
    /// </summary>
    public decimal Total => SubTotal + (AdditionsValue + (AdditionsPercent * SubTotal / 100)) + (TaxValue + (TaxPercent * SubTotal / 100)) - (DiscountValue - (DiscountPercent * SubTotal / 100));


    
    #endregion

    #region Constructors

    public OrderItem(string description, decimal unitPrice, decimal quantity)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
    public OrderItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal taxValue, decimal discountValue)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        AdditionsValue = additionsValue;
        TaxValue = taxValue;
        DiscountValue = discountValue;
    }

    #endregion

    #region Methods

    public void ChangeDescription(string description)
    {
        Description = description;
    }

    public void ChangeUnitPrice(decimal unitPrice)
    {
        UnitPrice = unitPrice;
    }

    public void UpdateQuantity(decimal quantity)
    {
        Quantity = quantity;
    }

    public void SetAdditionsValue(decimal additionsValue)
    {
        AdditionsValue = additionsValue;
    }

    public void SetAdditionsPercent(decimal additionsPercent)
    {
        AdditionsPercent = additionsPercent;
    }

    public void SetTaxValue(decimal taxValue)
    {
        TaxValue = taxValue;
    }

    public void SetTaxPercent(decimal taxPercent)
    {
        TaxPercent = taxPercent;
    }

    public void SetDiscountPercent(decimal discountPercent)
    {
        DiscountPercent = discountPercent;
    }

    public void SetDiscountValue(decimal discountValue)
    {
        DiscountValue = discountValue;
    }

    #endregion
}