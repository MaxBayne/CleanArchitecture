using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
