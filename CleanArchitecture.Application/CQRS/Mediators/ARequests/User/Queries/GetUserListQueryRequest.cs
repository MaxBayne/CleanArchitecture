using CleanArchitecture.Application.CQRS.Mediators.ARequests.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.ARequests.User.Queries
{
    public class GetUserListQueryRequest : RequestBase, IRequest<List<ViewUserDto>>
    {
    }
}
