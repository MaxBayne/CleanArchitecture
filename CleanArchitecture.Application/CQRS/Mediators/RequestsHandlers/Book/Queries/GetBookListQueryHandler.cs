using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Queries;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Queries;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;


namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.Book.Queries
{
    public class GetBookListQueryHandler :BaseHandler<IBookRepository>, IRequestHandler<GetBookListQueryRequest,QueryResponse<List<ViewBookDto>>>
    {
        public GetBookListQueryHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) {}

        public async Task<QueryResponse<List<ViewBookDto>>> Handle(GetBookListQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<List<ViewBookDto>>();

            try
            {
                //Get Data from Database using Repository as Entities
                var booksEntities = await Repository.GetAllAsync();

                //Convert Domain Entity to Dto using AutoMapper
                var booksDto = AutoMapper.Map<List<ViewBookDto>>(booksEntities);

                response.QueriedData = booksDto;
            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }

            return response;
        }

        
    }
}
