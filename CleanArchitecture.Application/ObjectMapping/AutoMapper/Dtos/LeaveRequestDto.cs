using CleanArchitecture.Application.ObjectMapping.AutoMapper.Bases;


namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos
{
    public class LeaveRequestDto : BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime ActionedDate { get; set; }
        public string Comments { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }

        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
    }
}
