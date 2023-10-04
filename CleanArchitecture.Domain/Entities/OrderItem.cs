using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities;

public class OrderItem:BaseEntity<int>
{
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
    public decimal Total => SubTotal + (AdditionsValue+(AdditionsPercent*SubTotal/100)) + (TaxValue+(TaxPercent*SubTotal/100)) - (DiscountValue-(DiscountPercent*SubTotal/100));


    public void ChangeDescription(string description)
    {
        Description=description;
    }

}