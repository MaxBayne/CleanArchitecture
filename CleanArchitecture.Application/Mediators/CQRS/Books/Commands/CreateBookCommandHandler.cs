using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Entities;



namespace CleanArchitecture.Application.Mediators.CQRS.Books.Commands
{
    public class CreateBookCommandHandler : RequestHandler<CreateBookCommand, Result<ViewBookDto>>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, INotificationPublisher notificationPublisher) : base(mapper, notificationPublisher)
        {
            _bookRepository = bookRepository;
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
                
                var newBookEntity = Book.Create(createBookDto.Title, createBookDto.Description, createBookDto.Category, createBookDto.IsActive);

                //Save Entity inside Database using Repository
                await _bookRepository.AddAsync(newBookEntity,true);
                
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
