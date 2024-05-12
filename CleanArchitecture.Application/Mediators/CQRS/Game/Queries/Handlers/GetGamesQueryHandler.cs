using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Requests;
using CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Responses;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Handlers
{
    public class GetGamesQueryHandler : QueryHandler<GetGamesQuery,GetGamesResponse>
    {
        private readonly IGameRepository _gameRepository;

        public GetGamesQueryHandler(IGameRepository gameRepository, IMapper mapper) : base(mapper)
        {
            _gameRepository = gameRepository;
        }
        
        public override async Task<Result<GetGamesResponse>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var gamesEntities = await _gameRepository.Get_All_Games_With_Genre_Async();
                
                //Convert Domain Entity to Dto using AutoMapper
                var gamesDto = AutoMapper.Map<List<ViewGameDto>>(gamesEntities);

                var response = new GetGamesResponse(gamesDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<GetGamesResponse>(e);
            }
        }
    }
}
