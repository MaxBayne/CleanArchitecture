using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveType
{
    public class ViewLeaveTypeDto : BaseDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
