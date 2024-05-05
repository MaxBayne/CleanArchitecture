using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Domain.Notifications.Game;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Notifications;

public class GameCreatedNotificationHandler : INotificationHandler<GameCreatedNotification>
{
    private readonly IGameRepository _gameRepository;

    public GameCreatedNotificationHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task Handle(GameCreatedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
        var createdGameExist = await _gameRepository.GetAsync(notification.Created.Id, true);

        if (createdGameExist == null)
        {
        }
    }
}