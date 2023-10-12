using MediatR;

namespace CleanArchitecture.Domain.Notifications.Order;

public class ItemRemovedFromOrderNotification:INotification
{

    #region Properties

    public int ItemId { get; private set; }
    public int OrderId { get; private set; }
    public DateTime RemovedDate { get; private set; }

    #endregion



    #region Constructors

    public ItemRemovedFromOrderNotification(int itemId, int orderId)
    {
        ItemId = itemId;
        OrderId = orderId;

        RemovedDate = DateTime.Now;
    }

    #endregion

}