using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Notifications.Genre;

namespace CleanArchitecture.Domain.Entities
{
    public class Genre : Entity<int>
    {
        #region Properites
        
        public string Name { get;private set; }

        #endregion

        #region Constructors

        public Genre()
        {
            Name = string.Empty;
        }

        public Genre(int id) : base(id)
        {
        }

        public Genre(string name)
        {
            Name = name;
        }

        public Genre(int id,string name) : base(id)
        {
            Name = name;
        }

        #endregion

        #region Factory Method

        public static Genre Create(string name)
        {
            var newGenre = new Genre(name);

            //Raise Event For Create Genre
            newGenre.RegisterNotification(new GenreCreatedNotification(newGenre));

            return newGenre;
        }
        public static Genre Create(int id)
        {
            var newGenre = new Genre(id);

            //Raise Event For Create Genre
            newGenre.RegisterNotification(new GenreCreatedNotification(newGenre));

            return newGenre;
        }
        public static Genre Create(int id, string name)
        {
            var newGenre = new Genre(id, name);

            //Raise Event For Create Genre
            newGenre.RegisterNotification(new GenreCreatedNotification(newGenre));

            return newGenre;
        }

        #endregion

        #region Methods

        public Result ChangeName(string name)
        {
            //validate
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure(GenreErrors.EmptyName);
            }

            Name = name;

            return Result.Success();
        }

        #endregion
    }
}
