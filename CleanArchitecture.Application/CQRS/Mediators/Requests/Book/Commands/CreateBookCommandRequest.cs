using MediatR;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;


namespace CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Commands
{
    public class CreateBookCommandRequest: BaseRequest, IRequest<CreateCommandResponse<ViewBookDto>>
    {
        public CreateBookDto? CreateBookDto { get; set; }
    }
}
