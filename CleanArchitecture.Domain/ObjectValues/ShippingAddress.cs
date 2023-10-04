using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.ObjectValues;

/// <summary>
/// عنوان الشحن
/// </summary>
public class ShippingAddress:BaseObjectValue
{
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Region { get; private set; }
    public string Street { get; private set; }
    public string Building { get; private set; }
    public string Floor { get; private set; }
    public string Apartment { get; private set; }


    public ShippingAddress()
    {
        Country = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        Street = string.Empty;
        Building = string.Empty;
        Floor = string.Empty;
        Apartment = string.Empty;
    }
    public ShippingAddress(string country, string city, string region, string street, string building, string floor, string apartment)
    {
        Country = country;
        City = city;
        Region = region;
        Street = street;
        Building = building;
        Floor = floor;
        Apartment = apartment;
    }
}