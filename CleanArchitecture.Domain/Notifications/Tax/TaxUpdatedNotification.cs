using MediatR;

namespace CleanArchitecture.Domain.Notifications.Tax;

public class TaxUpdatedNotification : INotification
{

    #region Properties

    public Entities.Tax Original { get; private set; }
    public Entities.Tax Updated { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public TaxUpdatedNotification(Entities.Tax original, Entities.Tax updated)
    {
        Original = original;
        Updated = updated;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}