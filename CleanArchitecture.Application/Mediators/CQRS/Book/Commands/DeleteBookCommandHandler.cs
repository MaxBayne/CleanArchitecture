using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class DeleteBookCommandHandler : CommandHandler<DeleteBookCommand, GetBookListResponse>
    {
        private readonly IBookRepository _bookRepository;
        

        public DeleteBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<Result<GetBookListResponse>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate 
                if (request.BookId == 0)
                {
                    return Result.Failure<GetBookListResponse>($"{nameof(request.BookId)} equal zero");
                }


                //check if original data exist or not
                var isExist = await _bookRepository.ExistAsync(request.BookId);
                if (isExist == false)
                {
                    return Result.Failure<GetBookListResponse>($"Book with Id {request.BookId} Not Found");
                }

                //Delete Book From Database
                await _bookRepository.DeleteAsync(request.BookId);

                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);

                var response = new GetBookListResponse();

                return Result.Success(response);

            }
            catch (Exception e)
            {
                return Result.Failure<GetBookListResponse>(e);
            }

         
        }
    }
}
