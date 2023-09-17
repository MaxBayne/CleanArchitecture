using CleanArchitecture.Domain.Bases;

namespace CleanArchitecture.Domain.Entities
{
    /// <summary>
    /// موقع المغادرة
    /// </summary>
    public class LeaveAllocation:BaseEntity
    {
        public int Id { get; set; }

        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        
        

        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }
    }
}
