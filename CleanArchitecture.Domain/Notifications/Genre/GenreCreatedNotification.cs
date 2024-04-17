using MediatR;

namespace CleanArchitecture.Domain.Notifications.Genre;

public class GenreCreatedNotification : INotification
{

    #region Properties

    public Entities.Genre Created { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public GenreCreatedNotification(Entities.Genre created)
    {
        Created = created;

        CreatedDate = DateTime.Now;
    }

    #endregion

}