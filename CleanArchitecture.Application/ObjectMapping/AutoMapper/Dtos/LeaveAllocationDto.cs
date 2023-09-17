using CleanArchitecture.Application.ObjectMapping.AutoMapper.Bases;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos
{
    public class LeaveAllocationDto : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public int Period { get; set; }



        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
    }
}
