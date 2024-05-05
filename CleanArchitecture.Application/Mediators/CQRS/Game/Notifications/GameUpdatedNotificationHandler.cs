using CleanArchitecture.Domain.Notifications.Game;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Notifications;

public class GameUpdatedNotificationHandler : INotificationHandler<GameUpdatedNotification>
{
    public async Task Handle(GameUpdatedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
    }
}