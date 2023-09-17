using CleanArchitecture.Application.ObjectMapping.AutoMapper.Bases;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveType;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveAllocation
{
    public class ViewLeaveAllocationDto : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public int Period { get; set; }



        public int LeaveTypeId { get; set; }
        public ViewLeaveTypeDto LeaveType { get; set; }
    }
}
