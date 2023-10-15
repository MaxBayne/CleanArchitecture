using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;


namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class DeleteBookCommandHandler : RequestHandler<DeleteBookCommand, Result>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : base(mapper)
        {
            _bookRepository = bookRepository;
        }

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
                var isExist = await _bookRepository.ExistAsync(request.BookId);
                if (isExist == false)
                {
                    return Result.Failure($"Book with Id {request.BookId} Not Found");
                }

                //Delete Book From Database
                await _bookRepository.DeleteAsync(request.BookId,true);

                return Result.Success();

            }
            catch (Exception e)
            {
                return Result.Failure(e);
            }

         
        }
    }
}
