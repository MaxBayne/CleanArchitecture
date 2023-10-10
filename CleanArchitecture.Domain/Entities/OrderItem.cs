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

    public void SetDiscountPercent(decimal discountPercent)
    {
        DiscountPercent = discountPercent;
    }

    public void SetDiscountValue(decimal discountValue)
    {
        DiscountValue = discountValue;
    }




    public void AddTaxValue(string taxName,decimal taxValue)
    {
        _itemTaxes.Add(new Tax(taxName, taxValue,true,Id,OrderId));

        CalcTaxesValue();
    }
    public void AddTaxPercent(string taxName, decimal taxPercent)
    {
        _itemTaxes.Add(new Tax(taxName, taxPercent,Id,OrderId));

        CalcTaxesPercent();
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