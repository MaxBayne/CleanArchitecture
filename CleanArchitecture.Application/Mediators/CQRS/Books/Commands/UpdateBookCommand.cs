using MediatR;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class UpdateBookCommand : IRequest<Result>
    {
        public int BookId { get; set; }

        public UpdateBookDto? UpdatedBookDto { get; set; }
    }
}
