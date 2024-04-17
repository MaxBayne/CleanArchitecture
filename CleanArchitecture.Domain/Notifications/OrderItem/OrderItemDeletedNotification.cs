using MediatR;

namespace CleanArchitecture.Domain.Notifications.OrderItem;

public class OrderItemDeletedNotification : INotification
{

    #region Properties

    public Entities.OrderItem Deleted { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public OrderItemDeletedNotification(Entities.OrderItem deleted)
    {
        Deleted = deleted;

        DeletedDate = DateTime.Now;
    }

    #endregion

}