using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands
{
    public class CreateUserCommandRequest: RequestBase, IRequest<ViewUserDto>
    {
        public CreateUserDto createUserDto { get; set; }
    }
}
