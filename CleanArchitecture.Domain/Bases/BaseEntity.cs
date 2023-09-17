using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Bases
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public User? CreatedBy {get;set;}
        public User? UpdatedBy { get; set; }
    }
}
