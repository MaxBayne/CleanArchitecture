using MediatR;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class DeleteBookCommand : IRequest<Result>
    {
        public int BookId { get; set; }
    }
}
