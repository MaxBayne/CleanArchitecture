﻿using MediatR;

namespace CleanArchitecture.Domain.Notifications.Order;

public class DescriptionChangedForOrderNotification:INotification
{
    #region Properties

    public string Original { get; private set; }
    public string Updated { get; private set; }

    public int OrderId { get; private set; }
    public DateTime ChangedDate { get; private set; }

    #endregion

    #region Constructors

    public DescriptionChangedForOrderNotification(string oldDescription, string newDescription, int orderId)
    {
        Original = oldDescription;
        Updated = newDescription;
        OrderId = orderId;

        ChangedDate = DateTime.Now;
    }


    #endregion
}