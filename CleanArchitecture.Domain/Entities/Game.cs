using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Notifications.Game;

namespace CleanArchitecture.Domain.Entities
{
    public class Game : Entity<int>
    {
        #region Properites

        public string Name { get; set; }
        public Genre? Genre { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        #endregion

        #region Constructors

        public Game()
        {
            Name = string.Empty;
            Genre=new Genre();
            Price = 0;
            Year = 0;
        }

        public Game(string name, Genre? genre,decimal price,int year)
        {
            Name = name;
            Genre= genre;
            Price = price;
            Year = year;
        }

        public Game(int id,string name, Genre? genre, decimal price, int year) : base(id)
        {
            Name = name;
            Genre = genre;
            Price = price;
            Year = year;
        }

        #endregion

        #region Factory Method

        public static Game Create()
        {
            var newGame = new Game();

            //Raise Event For Create Game
            newGame.RegisterNotification(new GameCreatedNotification(newGame));

            return newGame;
        }

        public static Game Create(string name,Genre? genre,decimal price,int year)
        {
            var newGame = new Game(name, genre, price, year);

            //Raise Event For Create Game
            newGame.RegisterNotification(new GameCreatedNotification(newGame));

            return newGame;
        }

        public static Game Create(int id, string name, Genre? genre, decimal price, int year)
        {
            var newGame = new Game(id,name, genre, price, year);

            //Raise Event For Create Game
            newGame.RegisterNotification(new GameCreatedNotification(newGame));

            return newGame;
        }


        #endregion

        #region Methods

        public Result ChangeName(string name)
        {
            //validate
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure(GameErrors.EmptyName);
            }

            Name = name;

            return Result.Success();
        }

        public Result ChangeGenre(Genre? genre)
        {
            //validate
            if (genre==null)
            {
                return Result.Failure(GameErrors.EmptyGenre);
            }

            Genre = genre;

            return Result.Success();
        }

        public Result SetPrice(decimal price)
        {
            //validate
            if (price==0)
            {
                return Result.Failure(GameErrors.ZeroPrice);
            }

            Price = price;

            return Result.Success();
        }

        public Result SetYear(int year)
        {
            //validate
            if (year == 0)
            {
                return Result.Failure(GameErrors.ZeroYear);
            }

            Year = year;

            return Result.Success();
        }

        #endregion
    }
}
