﻿using MediatR;

namespace CleanArchitecture.Domain.Notifications.Tax;

public class TaxCreatedNotification : INotification
{

    #region Properties

    public Entities.Tax Created { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public TaxCreatedNotification(Entities.Tax created)
    {
        Created = created;

        CreatedDate = DateTime.Now;
    }

    #endregion

}