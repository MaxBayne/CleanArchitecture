using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class ChangeUserAvailabilityDto : BaseDto
    {
        public bool? IsEnabled { get; set; }
    }
}
