using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Responses;



namespace CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Requests
{
    public record DeleteGameCommand(int GameId) : ICommand<DeleteGameResponse>;
}
