using MediatR;

namespace CleanArchitecture.Domain.Notifications.Genre;

public class GenreUpdatedNotification : INotification
{

    #region Properties

    public Entities.Genre Original { get; private set; }
    public Entities.Genre Updated { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public GenreUpdatedNotification(Entities.Genre original, Entities.Genre updated)
    {
        Original = original;
        Updated = updated;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}