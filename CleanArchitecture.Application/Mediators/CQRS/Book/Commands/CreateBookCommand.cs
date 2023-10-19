using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class CreateBookCommand : IRequest<Result<ViewBookDto>>
    {
        public CreateBookDto CreateBookDto { get; set; } = null!;
    }
}
