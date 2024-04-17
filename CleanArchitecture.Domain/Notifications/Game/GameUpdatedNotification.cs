using MediatR;

namespace CleanArchitecture.Domain.Notifications.Game;

public class GameUpdatedNotification : INotification
{

    #region Properties

    public Entities.Game Original { get; private set; }
    public Entities.Game Updated { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public GameUpdatedNotification(Entities.Game original,Entities.Game updated)
    {
        Original = original;
        Updated = updated;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}