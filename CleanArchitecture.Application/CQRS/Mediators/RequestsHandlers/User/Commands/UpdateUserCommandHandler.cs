using MediatR;
using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Persistence.Contracts;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.User;



namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    public class UpdateUserCommandHandler: BaseHandler<IUserRepository>, IRequestHandler<UpdateUserCommandRequest,UpdateCommandResponse<UserDto>>
    {
        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<UpdateCommandResponse<UserDto>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCommandResponse<UserDto>();


            //Validate Dto 
            var validator = await new UpdateUserDtoValidator().ValidateAsync(request.UpdatedUserDto!, cancellationToken);

            if (!validator.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Update User Failed";
                response.Errors = validator.Errors.Select(s => s.ErrorMessage).ToList();
                response.Exception = new ValidationException(validator);

                return response;
            }

            //check if original data exist or not
            var isExist = await Repository.ExistAsync(request.UserId);
            if (isExist == false)
            {
                response.IsSuccess = false;
                response.Errors.Add($"User with Id {request.UserId} Not Found");
                response.Exception = new NotFoundException(nameof(request.UserId), request.UserId);

                return response;
            }


            response.StopWatch.Start();

            //Get Old Entity From Database via Repository
            var oldUserEntity = await Repository.GetAsync(c => c.Id == request.UserId);
            var oldUserDto = AutoMapper.Map<UserDto>(oldUserEntity);

            //Update OldUserEntity using UpdatedUserDto powered by auto mapper
            var updatedUserEntity=AutoMapper.Map(request.UpdatedUserDto, oldUserEntity);
            var updatedUserDto = AutoMapper.Map<UserDto>(updatedUserEntity);
            
            //Save Updated Entity inside database
            var result = await Repository.UpdateAsync(updatedUserEntity);

            response.StopWatch.Stop();

            if (result)
            {
                response.IsSuccess = true;
                response.Message = "Update User Success";
                response.OriginalData = oldUserDto;
                response.UpdatedData = updatedUserDto;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Update User Fail via Repository";
            }


            return response;
        }

       
    }
}
