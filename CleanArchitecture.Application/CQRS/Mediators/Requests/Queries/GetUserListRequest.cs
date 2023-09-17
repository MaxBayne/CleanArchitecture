using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.Queries
{
    public class GetUserListRequest : IRequest<List<UserDto>>
    {
    }
}
