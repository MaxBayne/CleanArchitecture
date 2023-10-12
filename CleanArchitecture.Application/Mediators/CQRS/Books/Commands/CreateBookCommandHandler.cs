using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class CreateBookCommandHandler : RequestHandler<CreateBookCommand, Result<ViewBookDto>,IBookRepository>
    {
       
        public CreateBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) { }
        
        public override async Task<Result<ViewBookDto>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                var validator = await new CreateBookDtoValidator().ValidateAsync(request.CreateBookDto, cancellationToken);

                if (validator.IsValid == false)
                {
                    return Result.Failure(new ViewBookDto(), validator.Errors);
                }

                //Convert Dto To Domain Entity to can send it to database
                var bookEntity = AutoMapper.Map<Domain.Entities.Book>(request.CreateBookDto);

                //Send Entity to database via Repository
                var newBookEntity = await Repository.AddAsync(bookEntity);

                //Convert Entity To Dto
                var bookDto = AutoMapper.Map<ViewBookDto>(newBookEntity);


                return Result.Success(bookDto);
            }
            catch (Exception e)
            {
                return Result.Failure(new ViewBookDto(), e);
            }

           
        }
        


    }
}
