using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveType;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveRequest
{
    public class ViewLeaveRequestDto : BaseDto
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime ActionedDate { get; set; }
        public string Comments { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }

        public int LeaveTypeId { get; set; }
        public ViewLeaveTypeDto LeaveType { get; set; }
    }
}
