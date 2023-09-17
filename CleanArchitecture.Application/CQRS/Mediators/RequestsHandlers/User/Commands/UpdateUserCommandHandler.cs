using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    public class UpdateUserCommandHandler: HandlerBase<IUserRepository>, IRequestHandler<UpdateUserCommandRequest,bool>
    {
        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<bool> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            //Get Old Entity From Database via Repository
            var oldUserEntity = await Repository.GetAsync(c => c.Id == request.UserId);

            //Update OldUserEntity using UpdatedUserDto powered by auto mapper
            AutoMapper.Map(request.UpdatedUserDto, oldUserEntity);
            
            //Save Updated Entity inside database
            var updatedResult = await Repository.UpdateAsync(oldUserEntity);

            return updatedResult;
        }

       
    }
}
