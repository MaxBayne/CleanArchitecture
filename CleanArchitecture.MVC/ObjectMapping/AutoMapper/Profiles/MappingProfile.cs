using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.MVC.ViewModels.User;

namespace CleanArchitecture.MVC.ObjectMapping.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserViewModel>().ReverseMap();
            CreateMap<CreateUserDto, CreateUserViewModel>().ReverseMap();
            CreateMap<UpdateUserDto, UpdateUserViewModel>().ReverseMap();
            CreateMap<DeleteUserDto, DeleteUserViewModel>().ReverseMap();
            CreateMap<ChangeUserAvailabilityDto, ChangeUserAvailabilityViewModel>().ReverseMap();
            CreateMap<ChangeUserRoleDto, ChangeUserRoleViewModel>().ReverseMap();
            
            CreateMap<UserViewModel, CreateUserViewModel>().ReverseMap();
            CreateMap<UserViewModel, UpdateUserViewModel>().ReverseMap();
            CreateMap<UserViewModel, DeleteUserViewModel>().ReverseMap();
        }
    }
}
