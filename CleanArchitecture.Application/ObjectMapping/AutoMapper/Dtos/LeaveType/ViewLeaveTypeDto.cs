using CleanArchitecture.Application.ObjectMapping.AutoMapper.Bases;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveType
{
    public class ViewLeaveTypeDto : BaseDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
