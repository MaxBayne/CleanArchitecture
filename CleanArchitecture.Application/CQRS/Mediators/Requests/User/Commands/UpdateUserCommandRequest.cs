using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands
{
    public class UpdateUserCommandRequest : RequestBase, IRequest<bool>
    {
        public int UserId { get; set; }

        public UpdateUserDto? UpdatedUserDto { get; set; }
    }
}
