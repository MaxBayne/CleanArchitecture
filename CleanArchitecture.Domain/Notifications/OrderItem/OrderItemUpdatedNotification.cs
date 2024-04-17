using MediatR;

namespace CleanArchitecture.Domain.Notifications.OrderItem;

public class OrderItemUpdatedNotification : INotification
{

    #region Properties

    public Entities.OrderItem Original { get; private set; }
    public Entities.OrderItem Updated { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public OrderItemUpdatedNotification(Entities.OrderItem original, Entities.OrderItem updated)
    {
        Original = original;
        Updated = updated;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}