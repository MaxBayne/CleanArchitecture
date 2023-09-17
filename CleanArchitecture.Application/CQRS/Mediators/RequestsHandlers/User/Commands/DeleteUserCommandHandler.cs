using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    public class DeleteUserCommandHandler : HandlerBase<IUserRepository>, IRequestHandler<DeleteUserCommandRequest, bool>
    {
        public DeleteUserCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper){}

        public async Task<bool> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            //Validate 
            if (request.UserId is 0)
                throw new ValidationException($"{nameof(request.UserId)} equal zero");

            //Delete User From Database
            var result = await Repository.DeleteAsync(request.UserId);

            return result;
        }
    }
}
