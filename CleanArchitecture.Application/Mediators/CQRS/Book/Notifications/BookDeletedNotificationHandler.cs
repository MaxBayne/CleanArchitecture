using CleanArchitecture.Domain.Notifications.Book;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Notifications;

public class BookDeletedNotificationHandler : INotificationHandler<GenreDeletedNotification>
{
    public async Task Handle(GenreDeletedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
    }
}