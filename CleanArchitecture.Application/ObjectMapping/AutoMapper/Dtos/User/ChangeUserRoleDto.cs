using CleanArchitecture.Application.ObjectMapping.AutoMapper.Bases;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User
{
    public class ChangeUserRoleDto : BaseDTO
    {
        public string? Role { get; set; }
    }
}
