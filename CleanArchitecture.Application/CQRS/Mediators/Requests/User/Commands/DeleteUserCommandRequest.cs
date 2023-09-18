using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands
{
    public class DeleteUserCommandRequest : BaseRequest, IRequest<DeleteCommandResponse<UserDto>>
    {
        public int UserId { get; set; }
    }
}
