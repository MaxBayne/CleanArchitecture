using MediatR;

namespace CleanArchitecture.Domain.Notifications.Game;

public class GameCreatedNotification : INotification
{

    #region Properties

    public Entities.Game Created { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public GameCreatedNotification(Entities.Game created)
    {
        Created = created;

        CreatedDate = DateTime.Now;
    }

    #endregion

}