using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Queries;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;


namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Queries
{
    public class GetUserListQueryHandler :BaseHandler<IUserRepository>, IRequestHandler<GetUserListQueryRequest,QueryResponse<List<UserDto>>>
    {
        public GetUserListQueryHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) {}

        public async Task<QueryResponse<List<UserDto>>> Handle(GetUserListQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<List<UserDto>>();

            try
            {
                //Get Data from Database using Repository as Entities
                var usersEntities = await Repository.GetAllAsync();

                //Convert Domain Entity to Dto using AutoMapper
                var usersDto = AutoMapper.Map<List<UserDto>>(usersEntities);

                response.QueriedData = usersDto;
            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }

            return response;
        }

        
    }
}
