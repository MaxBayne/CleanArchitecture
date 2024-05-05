using CleanArchitecture.Domain.Notifications.Game;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Notifications;

public class GameDeletedNotificationHandler : INotificationHandler<GameDeletedNotification>
{
    public async Task Handle(GameDeletedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
    }
}