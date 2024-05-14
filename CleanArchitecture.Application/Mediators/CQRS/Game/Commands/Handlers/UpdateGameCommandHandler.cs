using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Requests;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Responses;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Handlers
{
    public class UpdateGameCommandHandler : CommandHandler<UpdateGameCommand, UpdateGameResponse>
    {
        private readonly IGameRepository _gameRepository;

        public UpdateGameCommandHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _gameRepository = gameRepository;
        }

        public override async Task<Result<UpdateGameResponse>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                //var validator = await new UpdateBookDtoValidator().ValidateAsync(request.UpdatedBookDto, cancellationToken);

                //if (validator.IsValid == false)
                //{
                //    return Result.Failure<UpdateGameResponse>(validator.Errors);
                //}

                //check if original data exist or not
                var isExist = await _gameRepository.ExistAsync(request.GameId);
                if (isExist == false)
                {
                    return Result.Failure<UpdateGameResponse>($"Game with Id {request.GameId} Not Found");
                }

                //Get current Entity From Database via Repository
                var currentGameEntity = await _gameRepository.GetAsync(c => c.Id == request.GameId);

                if (currentGameEntity is null)
                {
                    return Result.Failure<UpdateGameResponse>(GameErrors.NotFound);
                }

                //Update Current Entity with New Updated Entity
                currentGameEntity.ChangeName(request.UpdatedGameDto.Name);
                currentGameEntity.ChangeGenre(request.UpdatedGameDto.GenreId);
                currentGameEntity.SetPrice(request.UpdatedGameDto.Price);
                currentGameEntity.SetYear(request.UpdatedGameDto.Year);

                

                //Save Updated Entity inside database
                await _gameRepository.UpdateAsync(currentGameEntity);

                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);

                var response = new UpdateGameResponse();

                return Result.Success(response);

            }
            catch (Exception e)
            {
                return Result.Failure<UpdateGameResponse>(e);
            }
        }
    }
}
