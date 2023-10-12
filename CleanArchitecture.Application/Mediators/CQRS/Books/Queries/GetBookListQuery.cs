using MediatR;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Queries
{
    public class GetBookListQuery : IRequest<Result<List<ViewBookDto>>>
    {
    }
}
