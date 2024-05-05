using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Requests;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Responses;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Handlers
{
    public class CreateGameCommandHandler : CommandHandler<CreateGameCommand, CreateGameResponse>
    {
        private readonly IGameRepository _gameRepository;


        public CreateGameCommandHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork, IMapper mapper, INotificationPublisher notificationPublisher) : base(unitOfWork, mapper, notificationPublisher)
        {
            _gameRepository = gameRepository;
        }


        public override async Task<Result<CreateGameResponse>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                //var validator = await new CreateBookDtoValidator().ValidateAsync(request.createGameDto, cancellationToken);

                //if (validator.IsValid == false)
                //{
                //    return Result.Failure<CreateGameResponse>(validator.Errors);
                //}

                //Create Game using Entity
                var createGameDto = request.CreateGameDto;

                var newGameEntity = Domain.Entities.Game.Create(createGameDto.Name, createGameDto.Genre.Id, createGameDto.Price, createGameDto.Year);

                //Save Entity inside Database using Repository
                await _gameRepository.AddAsync(newGameEntity);


                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);


                //Publish All Notifications to its Handlers
                await NotificationPublisher.PublishNotificationsAsync(newGameEntity.Notifications, cancellationToken);

                //Convert Entity To Dto
                var gameDto = AutoMapper.Map<ViewGameDto>(newGameEntity);

                var response = new CreateGameResponse(gameDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<CreateGameResponse>(e);
            }
        }


    }
}
