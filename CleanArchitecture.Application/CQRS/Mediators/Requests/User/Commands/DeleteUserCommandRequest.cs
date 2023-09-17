using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands
{
    public class DeleteUserCommandRequest : RequestBase, IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
