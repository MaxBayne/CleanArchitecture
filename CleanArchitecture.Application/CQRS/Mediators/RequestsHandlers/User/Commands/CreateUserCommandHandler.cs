using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.User;


namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    public class CreateUserCommandHandler :BaseHandler<IUserRepository>, IRequestHandler<CreateUserCommandRequest,CreateCommandResponse<UserDto>>
    {
        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) {}

        public async Task<CreateCommandResponse<UserDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateCommandResponse<UserDto>();

            //Validate Dto 
            var validator = await new CreateUserDtoValidator().ValidateAsync(request.CreateUserDto!, cancellationToken);
            
            if (validator.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Create User Failed";
                response.Errors = validator.Errors.Select(s => s.ErrorMessage).ToList();
                response.Exception= new ValidationException(validator);

                return response;
            }

            //calc time of process execution
            response.StopWatch.Start();

            //Convert Dto To Domain Entity to can send it to database
            var userEntity = AutoMapper.Map<Domain.Entities.User>(request.CreateUserDto);

            //Send Entity to database via Repository
            var newUserEntity = await Repository.AddAsync(userEntity);

            //Convert Entity To Dto
            var userDto = AutoMapper.Map<UserDto>(newUserEntity);

            //prepare success response
            response.StopWatch.Stop();
            response.IsSuccess = true;
            response.Message = "Create User Success";
            response.CreatedData = userDto;
            

            return response;
        }

        
    }
}
