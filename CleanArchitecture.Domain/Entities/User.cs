using CleanArchitecture.Domain.Bases;
using CleanArchitecture.Domain.ObjectValues;

namespace CleanArchitecture.Domain.Entities
{
    public class User:BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        public Address Address { get; set; } = new();
    }
}
