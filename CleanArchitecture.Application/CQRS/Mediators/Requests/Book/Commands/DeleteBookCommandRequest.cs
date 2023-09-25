using MediatR;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;


namespace CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Commands
{
    public class DeleteBookCommandRequest : BaseRequest, IRequest<DeleteCommandResponse<ViewBookDto>>
    {
        public int BookId { get; set; }
    }
}
