using CleanArchitecture.Domain.Bases;

namespace CleanArchitecture.Domain.Entities
{
    /// <summary>
    /// طلب المغادرة
    /// </summary>
    public class LeaveRequest:BaseEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime ActionedDate { get; set; }
        public string? Comments { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }

        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }
    }
}
