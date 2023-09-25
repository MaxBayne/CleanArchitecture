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
    public class GetUserQueryHandler : BaseHandler<IBookRepository>, IRequestHandler<GetBookQueryRequest, QueryResponse<ViewBookDto>>
    {
        public GetUserQueryHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<QueryResponse<ViewBookDto>> Handle(GetBookQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<ViewBookDto>();

            try
            {
                //Get Data from Database using Repository as Entities
                var bookEntity = await Repository.GetAsync(request.BookId);

                //Convert Domain Entity to Dto using AutoMapper
                var bookDto = AutoMapper.Map<ViewBookDto>(bookEntity);

                response.QueriedData = bookDto;
            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }
            
            return response;
        }

       
    }
}
