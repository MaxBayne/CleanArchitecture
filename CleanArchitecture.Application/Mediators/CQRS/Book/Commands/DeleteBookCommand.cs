using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class DeleteBookCommand : IRequest<Result>
    {
        public int BookId { get; set; }
    }
}
