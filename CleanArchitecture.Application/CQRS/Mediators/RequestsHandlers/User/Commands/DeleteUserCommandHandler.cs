using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using MediatR;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;


namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    public class DeleteUserCommandHandler : BaseHandler<IUserRepository>, IRequestHandler<DeleteUserCommandRequest, DeleteCommandResponse<UserDto>>
    {
        public DeleteUserCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper){}

        public async Task<DeleteCommandResponse<UserDto>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCommandResponse<UserDto>();

            try
            {
                //Validate 
                if (request.UserId == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Delete User Failed";
                    response.Exception = new ValidationException($"{nameof(request.UserId)} equal zero");

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

                var originalUserEntity = await Repository.GetAsync(request.UserId);
                var originalUserDto = AutoMapper.Map<UserDto>(originalUserEntity);

                //Delete User From Database
                await Repository.DeleteAsync(request.UserId);

                response.IsSuccess = true;
                response.Message = "Delete User Success";
                response.DeletedData = originalUserDto;
                response.DeletedId = request.UserId;

            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }

            return response;
        }
    }
}
