using MediatR;

namespace CleanArchitecture.Domain.Notifications.Book;

public class BookDeletedNotification : INotification
{

    #region Properties

    public Entities.Book Deleted { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public BookDeletedNotification(Entities.Book deleted)
    {
        Deleted = deleted;

        DeletedDate = DateTime.Now;
    }

    #endregion

}