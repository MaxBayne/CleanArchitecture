using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands
{
    public class CreateUserCommandRequest: BaseRequest, IRequest<CreateCommandResponse<UserDto>>
    {
        public CreateUserDto? CreateUserDto { get; set; }
    }
}
