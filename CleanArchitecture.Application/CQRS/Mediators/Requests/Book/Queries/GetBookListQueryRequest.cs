using MediatR;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Queries;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;


namespace CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Queries
{
    public class GetBookListQueryRequest : BaseRequest, IRequest<QueryResponse<List<ViewBookDto>>>
    {
    }
}
