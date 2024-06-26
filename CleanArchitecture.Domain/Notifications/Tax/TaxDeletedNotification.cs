﻿using MediatR;

namespace CleanArchitecture.Domain.Notifications.Tax;

public class TaxDeletedNotification : INotification
{

    #region Properties

    public Entities.Tax Deleted { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public TaxDeletedNotification(Entities.Tax deleted)
    {
        Deleted = deleted;

        DeletedDate = DateTime.Now;
    }

    #endregion

}