using CleanArchitecture.Domain.Notifications.Order;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Orders.Notifications;

public class ItemRemovedFromOrderNotificationHandler : INotificationHandler<ItemRemovedFromOrderNotification>
{
    public async Task Handle(ItemRemovedFromOrderNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
    }
}