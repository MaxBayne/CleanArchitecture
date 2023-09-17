using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
