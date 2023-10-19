using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class UpdateBookCommand : IRequest<Result>
    {
        public int BookId { get; set; }

        public UpdateBookDto UpdatedBookDto { get; set; } = null!;

        public int UpdatedById { get; set;}
    }
}
