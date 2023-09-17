using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Commands
{
    public class CreateUserCommandHandler :HandlerBase<IUserRepository>, IRequestHandler<CreateUserCommandRequest, ViewUserDto>
    {
        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ViewUserDto> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            //Convert Dto To Domain Entity to can send it to database
            var userEntity = AutoMapper.Map<Domain.Entities.User>(request.createUserDto);

            //Send Entity to database via Repository
            var newUserEntity = await Repository.AddAsync(userEntity);

            //Convert Entity To Dto
            var userDto = AutoMapper.Map<ViewUserDto>(newUserEntity);

            return userDto;
        }

        
    }
}
