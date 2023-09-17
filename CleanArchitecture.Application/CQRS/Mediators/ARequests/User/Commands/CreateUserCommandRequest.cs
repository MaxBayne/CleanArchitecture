using CleanArchitecture.Application.CQRS.Mediators.ARequests.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.ARequests.User.Commands
{
    public class CreateUserCommandRequest: RequestBase, IRequest<ViewUserDto>
    {
        public CreateUserDto createUserDto { get; set; }
    }
}
