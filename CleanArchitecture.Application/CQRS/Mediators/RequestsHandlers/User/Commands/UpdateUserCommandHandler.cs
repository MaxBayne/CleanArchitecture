using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.Models.Infrastructure;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.User;



namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    public class UpdateUserCommandHandler: BaseHandler<IUserRepository>, IRequestHandler<UpdateUserCommandRequest,UpdateCommandResponse<UserDto>>
    {
        private readonly IEmailSenderService _emailSenderService;

        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper,IEmailSenderService emailSenderService) : base(repository, mapper)
        {
            _emailSenderService = emailSenderService;
        }

        public async Task<UpdateCommandResponse<UserDto>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCommandResponse<UserDto>();

            try
            {
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
                var updatedUserEntity = AutoMapper.Map(request.UpdatedUserDto, oldUserEntity);
                var updatedUserDto = AutoMapper.Map<UserDto>(updatedUserEntity);

                //Save Updated Entity inside database
                await Repository.UpdateAsync(updatedUserEntity!);

                response.StopWatch.Stop();

                response.IsSuccess = true;
                response.Message = "Update User Success";
                response.OriginalData = oldUserDto;
                response.UpdatedData = updatedUserDto;

                //Send Email Notification To User to say you info updated
                await _emailSenderService.SendEmailAsync(new Email()
                {
                    To = updatedUserDto.Email,
                    Subject = "User Profile Updated",
                    Body = $"your profile updated at {DateTime.Now}"

                });

            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }

            return response;
        }

       
    }
}
