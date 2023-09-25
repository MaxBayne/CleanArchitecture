using CleanArchitecture.Domain.Bases;

namespace CleanArchitecture.Domain.Entities
{
    public class Book:BaseEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool? IsActive { get; set; }
    }
}
