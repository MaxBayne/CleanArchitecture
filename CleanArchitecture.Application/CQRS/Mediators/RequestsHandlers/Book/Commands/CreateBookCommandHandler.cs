using MediatR;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using CleanArchitecture.Application.CQRS.Mediators.Abstract;
using CleanArchitecture.Application.CQRS.Mediators.Requests.Book.Commands;
using CleanArchitecture.Application.CQRS.Mediators.Responses.Commands;
using CleanArchitecture.Application.HandleExceptions.Exceptions;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;


namespace CleanArchitecture.Application.CQRS.Mediators.RequestsHandlers.Book.Commands
{
    public class CreateBookCommandHandler : BaseHandler<IBookRepository>, IRequestHandler<CreateBookCommandRequest, CreateCommandResponse<ViewBookDto>>
    {
        public CreateBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<CreateCommandResponse<ViewBookDto>> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateCommandResponse<ViewBookDto>();

            try
            {
                //Validate Dto 
                var validator = await new CreateBookDtoValidator().ValidateAsync(request.CreateBookDto!, cancellationToken);

                if (validator.IsValid == false)
                {
                    response.IsSuccess = false;
                    response.Message = "Create Book Failed";
                    response.Errors = validator.Errors.Select(s => s.ErrorMessage).ToList();
                    response.Exception = new ValidationException(validator);

                    return response;
                }

                //calc time of process execution
                response.StopWatch.Start();

                //Convert Dto To Domain Entity to can send it to database
                var bookEntity = AutoMapper.Map<Domain.Entities.Book>(request.CreateBookDto);

                //Send Entity to database via Repository
                var newBookEntity = await Repository.AddAsync(bookEntity);

                //Convert Entity To Dto
                var bookDto = AutoMapper.Map<ViewBookDto>(newBookEntity);

                //prepare success response
                response.StopWatch.Stop();
                response.IsSuccess = true;
                response.Message = "Create Book Success";
                response.CreatedData = bookDto;

            }
            catch (Exception e)
            {
                response.Exception = new BadRequestException(e.Message);
            }

            return response;
        }


    }
}
