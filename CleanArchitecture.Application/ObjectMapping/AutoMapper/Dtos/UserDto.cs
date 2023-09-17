using CleanArchitecture.Application.ObjectMapping.AutoMapper.Bases;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos
{
    public class UserDto : BaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
