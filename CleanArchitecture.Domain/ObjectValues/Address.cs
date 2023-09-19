using CleanArchitecture.Domain.Bases;

namespace CleanArchitecture.Domain.ObjectValues
{
    public class Address: BaseObjectValue
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }  
    }
}
