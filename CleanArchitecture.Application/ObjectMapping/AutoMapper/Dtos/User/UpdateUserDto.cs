using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class UpdateUserDto:BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
