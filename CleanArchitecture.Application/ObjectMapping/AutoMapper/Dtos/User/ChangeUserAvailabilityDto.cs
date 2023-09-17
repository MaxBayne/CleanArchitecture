using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class ChangeUserAvailabilityDto : BaseDTO
    {
        public bool? IsEnabled { get; set; }
    }
}
