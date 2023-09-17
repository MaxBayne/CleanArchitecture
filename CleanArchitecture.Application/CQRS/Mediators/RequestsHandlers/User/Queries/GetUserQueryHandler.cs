using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.User.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.User.Queries
{
    public class GetUserQueryHandler : HandlerBase<IUserRepository>, IRequestHandler<GetUserQueryRequest, ViewUserDto>
    {
        public GetUserQueryHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ViewUserDto> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            //Get Data from Database using Repository as Entities
            var userEntity = await Repository.GetAsync(request.UserId);

            //Convert Domain Entity to Dto using AutoMapper
            var userDto = AutoMapper.Map<ViewUserDto>(userEntity);

            return userDto;
        }

       
    }
}
