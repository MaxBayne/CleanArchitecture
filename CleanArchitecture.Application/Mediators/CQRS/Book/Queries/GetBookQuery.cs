using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Queries
{
    public class GetBookQuery : IRequest<Result<ViewBookDto>>
    {
        public int BookId { get; set; }
    }
}
