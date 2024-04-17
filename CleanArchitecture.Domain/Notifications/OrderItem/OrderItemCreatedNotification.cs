using MediatR;

namespace CleanArchitecture.Domain.Notifications.OrderItem;

public class OrderItemCreatedNotification : INotification
{

    #region Properties

    public Entities.OrderItem Created { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public OrderItemCreatedNotification(Entities.OrderItem created)
    {
        Created = created;

        CreatedDate = DateTime.Now;
    }

    #endregion

}