using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.ValueObjects
{
    /// <summary>
    ///العنوان
    /// </summary>
    public class Address: ValueObject
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Region { get; private set; }
        public string Street { get; private set; }

        public Address()
        {
            Country = string.Empty;
            City = string.Empty;
            Region = string.Empty;
            Street = string.Empty;
        }
        public Address(string country, string city, string region, string street)
        {
            Country = country;
            City = city;
            Region = region;
            Street = street;
        }
        
    }
}
