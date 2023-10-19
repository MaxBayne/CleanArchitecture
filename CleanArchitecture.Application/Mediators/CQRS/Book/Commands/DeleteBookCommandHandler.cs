using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class DeleteBookCommandHandler : RequestHandler<DeleteBookCommand, Result>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork,IBookRepository bookRepository, IMapper mapper) : base(mapper)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
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
                await _bookRepository.DeleteAsync(request.BookId);

                //Save Changes using Unit of Work Pattern
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success();

            }
            catch (Exception e)
            {
                return Result.Failure(e);
            }

         
        }
    }
}
