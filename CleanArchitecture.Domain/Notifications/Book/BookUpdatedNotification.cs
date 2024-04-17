using MediatR;

namespace CleanArchitecture.Domain.Notifications.Book;

public class BookUpdatedNotification : INotification
{

    #region Properties

    public Entities.Book Original { get; private set; }
    public Entities.Book Updated { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public BookUpdatedNotification(Entities.Book original,Entities.Book updated)
    {
        Original = original;
        Updated=updated;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}