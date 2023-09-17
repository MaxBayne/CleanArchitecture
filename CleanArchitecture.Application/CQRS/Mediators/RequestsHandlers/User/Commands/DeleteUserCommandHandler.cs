using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Persistence.Contracts;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.User;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    //public class DeleteUserCommandHandler : HandlerBase<IUserRepository>, IRequestHandler<DeleteUserCommandRequest,bool>
    //{
    //    public DeleteUserCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

    //    //public async Task<bool> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    //    //{
    //    //    //Validate Dto 
    //    //    var validator = await new UpdateUserDtoValidator().ValidateAsync(request.UpdatedUserDto!, cancellationToken);

    //    //    if (!validator.IsValid)
    //    //        throw new Exception(validator.Errors.ToString());

    //    //    //Get Old Entity From Database via Repository
    //    //    var oldUserEntity = await Repository.GetAsync(c => c.Id == request.UserId);

    //    //    //Update OldUserEntity using UpdatedUserDto powered by auto mapper
    //    //    AutoMapper.Map(request.UpdatedUserDto, oldUserEntity);
            
    //    //    //Save Updated Entity inside database
    //    //    var updatedResult = await Repository.UpdateAsync(oldUserEntity);

    //    //    return updatedResult;
    //    //}


    //    //public async Task<bool> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    //    //{
    //    //    //Validate Dto 
    //    //    var validator = await new DeleteUserDtoValidator().ValidateAsync(request, cancellationToken);

    //    //}
    //}
}
