using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries
{
    public class GetUserQueryRequest : BaseRequest, IRequest<QueryResponse<UserDto>>
    {
        public int UserId { get; set; }
    }
}
