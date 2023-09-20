using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;


namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class CreateUserDto: BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsEnabled { get; set; }
        public string Password { get; set; }
    }
}
