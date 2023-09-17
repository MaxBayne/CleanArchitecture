using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos;
using CleanArchitecture.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Handlers.Queries
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _autoMapper;

        public GetUserRequestHandler(IUserRepository userRepository, IMapper autoMapper)
        {
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }

        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            //Get Data from Database using Repository as Entities
            var userEntity = await _userRepository.GetAsync(request.UserId);

            //Convert Domain Entity to Dto using AutoMapper
            var userDto = _autoMapper.Map<UserDto>(userEntity);

            return userDto;
        }
    }
}
