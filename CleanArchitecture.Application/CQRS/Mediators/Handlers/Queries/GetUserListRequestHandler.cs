using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos;
using CleanArchitecture.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _autoMapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper autoMapper)
        {
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<UserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            //Get Data from Database using Repository as Entities
            var usersEntities = await _userRepository.GetAllAsync();

            //Convert Domain Entity to Dto using AutoMapper
            var usersDto = _autoMapper.Map<List<UserDto>>(usersEntities);

            return usersDto;

        }
    }
}
