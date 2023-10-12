using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;


namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class DeleteBookCommandHandler : RequestHandler<DeleteBookCommand, Result,IBookRepository>
    {
        public DeleteBookCommandHandler(IBookRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate 
                if (request.BookId == 0)
                {
                    return Result.Failure($"{nameof(request.BookId)} equal zero");
                }


                //check if original data exist or not
                var isExist = await Repository.ExistAsync(request.BookId);
                if (isExist == false)
                {
                    return Result.Failure($"Book with Id {request.BookId} Not Found");
                }

                //Delete Book From Database
                await Repository.DeleteAsync(request.BookId);

                return Result.Success();

            }
            catch (Exception e)
            {
                return Result.Failure(e);
            }

         
        }
    }
}
