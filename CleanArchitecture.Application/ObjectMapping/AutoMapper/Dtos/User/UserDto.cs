using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class UserDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsEnabled { get; set; }
    }
}
