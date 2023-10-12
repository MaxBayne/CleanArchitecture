using MediatR;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class CreateBookCommand : IRequest<Result<ViewBookDto>>
    {
        public CreateBookDto CreateBookDto { get; set; } = null!;
    }
}
