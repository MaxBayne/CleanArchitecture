using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Responses;

public record GetGamesResponse(List<ViewGameDto> ViewGamesDto);


