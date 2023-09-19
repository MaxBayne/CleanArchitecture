using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;


namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Queries
{
    public class GetUserQueryHandler : BaseHandler<IUserRepository>, IRequestHandler<GetUserQueryRequest, QueryResponse<UserDto>>
    {
        public GetUserQueryHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<QueryResponse<UserDto>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<UserDto>();

            //Get Data from Database using Repository as Entities
            var userEntity = await Repository.GetAsync(request.UserId);

            //Convert Domain Entity to Dto using AutoMapper
            var userDto = AutoMapper.Map<UserDto>(userEntity);

            response.QueriedData = userDto;
            
            return response;
        }

       
    }
}
