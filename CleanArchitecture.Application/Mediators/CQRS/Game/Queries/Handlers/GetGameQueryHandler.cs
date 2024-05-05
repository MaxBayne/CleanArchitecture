using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Requests;
using CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Responses;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Handlers
{
    public class GetGameQueryHandler : QueryHandler<GetGameQuery, GetGameResponse>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameQueryHandler(IGameRepository gameRepository, IMapper mapper) : base(mapper)
        {
            _gameRepository = gameRepository;
        }

        
        public override async Task<Result<GetGameResponse>> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var gameEntity = await _gameRepository.GetAsync(request.GameId);

                if (gameEntity is null)
                    return Result.Failure<GetGameResponse>(GameErrors.NotFound);

                //Convert Domain Entity to Dto using AutoMapper
                var gameDto = AutoMapper.Map<ViewGameDto>(gameEntity);

                var response = new GetGameResponse(gameDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<GetGameResponse>(e);
            }
        }
        


    }
}
