using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
