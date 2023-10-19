using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class CreateBookCommandHandler : RequestHandler<CreateBookCommand, Result<ViewBookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork ,IBookRepository bookRepository, IMapper mapper, INotificationPublisher notificationPublisher) : base(mapper, notificationPublisher)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        
        public override async Task<Result<ViewBookDto>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                var validator = await new CreateBookDtoValidator().ValidateAsync(request.CreateBookDto, cancellationToken);

                if (validator.IsValid == false)
                {
                    return Result.Failure<ViewBookDto>(validator.Errors);
                }

                //Create Book using Entity
                var createBookDto = request.CreateBookDto;
                
                var newBookEntity = Domain.Entities.Book.Create(createBookDto.Title, createBookDto.Description, createBookDto.Category, createBookDto.IsActive);

                //Save Entity inside Database using Repository
                await _bookRepository.AddAsync(newBookEntity);

                
                //Save Changes using Unit of Work Pattern
                await _unitOfWork.SaveChangesAsync(cancellationToken);


                //Publish All Notifications to its Handlers
                await NotificationPublisher.PublishNotificationsAsync(newBookEntity.Notifications, cancellationToken);

                //Convert Entity To Dto
                var bookDto = AutoMapper.Map<ViewBookDto>(newBookEntity);

                return Result.Success(bookDto);
            }
            catch (Exception e)
            {
                return Result.Failure<ViewBookDto>(e);
            }
        }
    }
}
