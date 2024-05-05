using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Requests;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Responses;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Handlers
{
    public class DeleteGameCommandHandler : CommandHandler<DeleteGameCommand, DeleteGameResponse>
    {
        private readonly IGameRepository _gameRepository;


        public DeleteGameCommandHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _gameRepository = gameRepository;
        }

        public override async Task<Result<DeleteGameResponse>> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate 
                if (request.GameId == 0)
                {
                    return Result.Failure<DeleteGameResponse>($"{nameof(request.GameId)} equal zero");
                }


                //check if original data exist or not
                var isExist = await _gameRepository.ExistAsync(request.GameId);
                if (isExist == false)
                {
                    return Result.Failure<DeleteGameResponse>($"Game with Id {request.GameId} Not Found");
                }

                //Delete Game From Database
                await _gameRepository.DeleteAsync(request.GameId);

                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);

                var response = new DeleteGameResponse();

                return Result.Success(response);

            }
            catch (Exception e)
            {
                return Result.Failure<DeleteGameResponse>(e);
            }


        }
    }
}
