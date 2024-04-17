using MediatR;

namespace CleanArchitecture.Domain.Notifications.Game;

public class GameDeletedNotification : INotification
{

    #region Properties

    public Entities.Game Deleted { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public GameDeletedNotification(Entities.Game deleted)
    {
        Deleted = deleted;

        DeletedDate = DateTime.Now;
    }

    #endregion

}