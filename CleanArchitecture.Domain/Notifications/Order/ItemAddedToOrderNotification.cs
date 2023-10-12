using MediatR;

namespace CleanArchitecture.Domain.Notifications.Order;

public class ItemAddedToOrderNotification : INotification
{

    #region Properties

    public int ItemId { get; private set; }
    public int OrderId { get; private set; }
    public DateTime AddedDate { get; private set; }

    #endregion



    #region Constructors

    public ItemAddedToOrderNotification(int itemId, int orderId)
    {
        ItemId = itemId;
        OrderId = orderId;

        AddedDate = DateTime.Now;
    }

    #endregion

}