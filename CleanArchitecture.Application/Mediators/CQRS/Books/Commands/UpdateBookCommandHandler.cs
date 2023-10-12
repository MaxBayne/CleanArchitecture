using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class UpdateBookCommandHandler : RequestHandler<UpdateBookCommand, Result, IBookRepository>
    {
        public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                var validator = await new UpdateBookDtoValidator().ValidateAsync(request.UpdatedBookDto!, cancellationToken);

                if (validator.IsValid==false)
                {
                    return Result.Failure(validator.Errors);
                }

                //check if original data exist or not
                var isExist = await Repository.ExistAsync(request.BookId);
                if (isExist == false)
                {
                    return Result.Failure($"Book with Id {request.BookId} Not Found");
                }

                //Get Old Entity From Database via Repository
                var oldBookEntity = await Repository.GetAsync(c => c.Id == request.BookId);
                //var oldBookDto = AutoMapper.Map<ViewBookDto>(oldBookEntity);

                //Update OldBookEntity using UpdatedBookDto powered by auto mapper
                var updatedBookEntity = AutoMapper.Map(request.UpdatedBookDto, oldBookEntity);
                //var updatedBookDto = AutoMapper.Map<ViewBookDto>(updatedBookEntity);

                //Save Updated Entity inside database
                await Repository.UpdateAsync(updatedBookEntity!);

                return Result.Success();

            }
            catch (Exception e)
            {
                return Result.Failure(e);
            }
        }


    }
}
