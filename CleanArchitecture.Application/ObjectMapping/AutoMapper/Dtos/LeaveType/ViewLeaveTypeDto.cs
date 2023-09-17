using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveType
{
    public class ViewLeaveTypeDto : BaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
