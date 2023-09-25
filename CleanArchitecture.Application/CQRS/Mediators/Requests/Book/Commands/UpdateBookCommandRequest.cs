using MediatR;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;


namespace CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Commands
{
    public class UpdateBookCommandRequest : BaseRequest, IRequest<UpdateCommandResponse<ViewBookDto>>
    {
        public int BookId { get; set; }

        public UpdateBookDto? UpdatedBookDto { get; set; }
    }
}
