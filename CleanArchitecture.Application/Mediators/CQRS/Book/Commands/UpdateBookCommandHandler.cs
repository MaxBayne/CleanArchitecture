using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class UpdateBookCommandHandler : RequestHandler<UpdateBookCommand, Result>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork,IBookRepository bookRepository, IMapper mapper) : base(mapper)
        {
            _bookRepository=bookRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                var validator = await new UpdateBookDtoValidator().ValidateAsync(request.UpdatedBookDto, cancellationToken);

                if (validator.IsValid==false)
                {
                    return Result.Failure(validator.Errors);
                }

                //check if original data exist or not
                var isExist = await _bookRepository.ExistAsync(request.BookId);
                if (isExist == false)
                {
                    return Result.Failure($"Book with Id {request.BookId} Not Found");
                }

                //Get Old Entity From Database via Repository
                var oldBookEntity = await _bookRepository.GetAsync(c => c.Id == request.BookId);
                //var oldBookDto = AutoMapper.Map<ViewBookDto>(oldBookEntity);

                if (oldBookEntity is null)
                {
                    return Result.Failure("Book Id Not Exist");
                }

                oldBookEntity.Update(request.UpdatedBookDto.Title, request.UpdatedBookDto.Description, request.UpdatedBookDto.Category, request.UpdatedBookDto.IsActive,request.UpdatedById);

                //Update OldBookEntity using UpdatedBookDto powered by auto mapper
                //var updatedBookEntity = AutoMapper.Map(request.UpdatedBookDto, oldBookEntity);
                //var updatedBookDto = AutoMapper.Map<ViewBookDto>(updatedBookEntity);

                //Save Updated Entity inside database
                //await _bookRepository.UpdateAsync(updatedBookEntity!);
                await _bookRepository.UpdateAsync(oldBookEntity);

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
