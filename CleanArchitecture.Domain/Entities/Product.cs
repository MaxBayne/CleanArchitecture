using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities;

public class Product : BaseEntity<int>
{
    public string Name { get; private set; }
    public string Category { get; private set; }
    public decimal UnitPrice { get; private set; }
    public bool IsActive { get; private set; }
    public Unit Unit { get; private set; }


    public Product()
    {
        Name = string.Empty;
        Category = string.Empty;
        UnitPrice = default;
        IsActive = true;
        Unit = new Unit();
    }
    public Product(string name, string category, decimal unitPrice, bool isActive, Unit unit)
    {
        Name = name;
        Category = category;
        UnitPrice = unitPrice;
        IsActive = isActive;
        Unit = unit;
    }

    public void ChangeName(string name)
    {
        Name=name;
    }

    public void ChangeCategory(string category)
    {
        Category=category;
    }

    public void ChangeUnitPrice(decimal price)
    {
        UnitPrice=price;
    }

    public void EnableProduct()
    {
        IsActive = true;
    }

    public void DisableProduct()
    {
        IsActive = false;
    }

    public void ChangeUnit(Unit unit)
    {
        Unit=unit;
    }
    
    
}