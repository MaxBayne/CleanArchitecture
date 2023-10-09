using MediatR;
using AutoMapper;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;



namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.Book.Commands
{
    public class UpdateBookCommandHandler: BaseHandler<IBookRepository>, IRequestHandler<UpdateBookCommandRequest,UpdateCommandResponse<ViewBookDto>>
    {
        public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) {}

        public async Task<UpdateCommandResponse<ViewBookDto>> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCommandResponse<ViewBookDto>();

            try
            {
                //Validate Dto 
                var validator = await new UpdateBookDtoValidator().ValidateAsync(request.UpdatedBookDto!, cancellationToken);

                if (!validator.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = "Update Book Failed";
                    response.Errors = validator.Errors.Select(s => s.ErrorMessage).ToList();
                    response.Exception = new ValidationException(validator);

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


                response.StopWatch.Start();

                //Get Old Entity From Database via Repository
                var oldBookEntity = await Repository.GetAsync(c => c.Id == request.BookId);
                var oldBookDto = AutoMapper.Map<ViewBookDto>(oldBookEntity);

                //Update OldBookEntity using UpdatedBookDto powered by auto mapper
                var updatedBookEntity = AutoMapper.Map(request.UpdatedBookDto, oldBookEntity);
                var updatedBookDto = AutoMapper.Map<ViewBookDto>(updatedBookEntity);

                //Save Updated Entity inside database
                await Repository.UpdateAsync(updatedBookEntity!);

                response.StopWatch.Stop();

                response.IsSuccess = true;
                response.Message = "Update Book Success";
                response.OriginalData = oldBookDto;
                response.UpdatedData = updatedBookDto;

            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }

            return response;
        }

       
    }
}
