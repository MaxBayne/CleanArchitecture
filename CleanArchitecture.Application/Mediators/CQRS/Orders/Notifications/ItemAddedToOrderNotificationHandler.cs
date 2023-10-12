using CleanArchitecture.Domain.Notifications.Order;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Orders.Notifications;

public class ItemAddedToOrderNotificationHandler : INotificationHandler<ItemAddedToOrderNotification>
{
    public async Task Handle(ItemAddedToOrderNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
    }
}