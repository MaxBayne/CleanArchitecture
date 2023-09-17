using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries
{
    public class GetUserListQueryRequest : RequestBase, IRequest<List<ViewUserDto>>
    {
    }
}
