using MediatR;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Queries
{
    public class GetBookQuery : IRequest<Result<ViewBookDto>>
    {
        public int BookId { get; set; }
    }
}
