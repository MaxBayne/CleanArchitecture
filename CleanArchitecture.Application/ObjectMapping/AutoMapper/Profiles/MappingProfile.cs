using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveAllocation;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveRequest;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.LeaveType;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveAllocation, ViewLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveRequest, ViewLeaveRequestDto>().ReverseMap();

            CreateMap<LeaveType, ViewLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();

            CreateMap<User, ViewUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

        }
    }
}
