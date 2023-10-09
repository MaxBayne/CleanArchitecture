using AutoMapper;
using MediatR;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;


namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.Book.Commands
{
    public class DeleteBookCommandHandler : BaseHandler<IBookRepository>, IRequestHandler<DeleteBookCommandRequest, DeleteCommandResponse<ViewBookDto>>
    {
        public DeleteBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper){}

        public async Task<DeleteCommandResponse<ViewBookDto>> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCommandResponse<ViewBookDto>();

            try
            {
                //Validate 
                if (request.BookId == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Delete Book Failed";
                    response.Exception = new ValidationException($"{nameof(request.BookId)} equal zero");

                    return response;
                }


                //check if original data exist or not
                var isExist = await Repository.ExistAsync(request.BookId);
                if (isExist == false)
                {
                    response.IsSuccess = false;
                    response.Errors.Add($"Book with Id {request.BookId} Not Found");
                    response.Exception = new NotFoundException(nameof(request.BookId), request.BookId);

                    return response;
                }

                var originalBookEntity = await Repository.GetAsync(request.BookId);
                var originalBookDto = AutoMapper.Map<ViewBookDto>(originalBookEntity);

                //Delete Book From Database
                await Repository.DeleteAsync(request.BookId);

                response.IsSuccess = true;
                response.Message = "Delete Book Success";
                response.DeletedData = originalBookDto;
                response.DeletedId = request.BookId;

            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }

            return response;
        }
    }
}
