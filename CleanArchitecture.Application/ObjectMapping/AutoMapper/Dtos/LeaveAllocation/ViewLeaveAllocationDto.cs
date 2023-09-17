using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveType;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveAllocation
{
    public class ViewLeaveAllocationDto : BaseDto
    {
        public int Id { get; set; }

        public int NumberOfDays { get; set; }
        public int Period { get; set; }



        public int LeaveTypeId { get; set; }
        public ViewLeaveTypeDto LeaveType { get; set; }
    }
}
