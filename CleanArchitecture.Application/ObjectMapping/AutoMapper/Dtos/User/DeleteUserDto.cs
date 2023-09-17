using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class DeleteUserDto : BaseDto
    {
        public int UserId { get; set; }
    }
}
