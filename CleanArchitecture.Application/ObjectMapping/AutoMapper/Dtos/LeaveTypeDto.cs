using CleanArchitecture.Application.ObjectMapping.AutoMapper.Bases;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos
{
    public class LeaveTypeDto : BaseDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
