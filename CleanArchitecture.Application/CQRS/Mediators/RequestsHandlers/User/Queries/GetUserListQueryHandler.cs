using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Queries
{
    public class GetUserListQueryHandler :HandlerBase<IUserRepository>, IRequestHandler<GetUserListQueryRequest, List<ViewUserDto>>
    {
        public GetUserListQueryHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) {}

        public async Task<List<ViewUserDto>> Handle(GetUserListQueryRequest request, CancellationToken cancellationToken)
        {
            //Get Data from Database using Repository as Entities
            var usersEntities = await Repository.GetAllAsync();

            //Convert Domain Entity to Dto using AutoMapper
            var usersDto = AutoMapper.Map<List<ViewUserDto>>(usersEntities);

            return usersDto;

        }

        
    }
}
