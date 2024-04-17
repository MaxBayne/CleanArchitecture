using MediatR;

namespace CleanArchitecture.Domain.Notifications.Book;

public class BookCreatedNotification : INotification
{

    #region Properties

    public Entities.Book Created { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public BookCreatedNotification(Entities.Book created)
    {
        Created = created;

        CreatedDate = DateTime.Now;
    }

    #endregion

}