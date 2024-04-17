using MediatR;

namespace CleanArchitecture.Domain.Notifications.Genre;

public class GenreDeletedNotification : INotification
{

    #region Properties

    public Entities.Genre Deleted { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public GenreDeletedNotification(Entities.Genre deleted)
    {
        Deleted = deleted;

        DeletedDate = DateTime.Now;
    }

    #endregion

}