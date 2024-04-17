using CleanArchitecture.Blazor.Clients.Abstract;
using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Blazor.Clients.Implements;


// ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
public class GamesClient : BaseClient, IGamesClient
{
    private readonly List<Game> _gamesList;
    private readonly IGenresClient _genresClient;

    public GamesClient(IGenresClient genresClient)
    {
        _genresClient = genresClient;
        _gamesList = new List<Game>()
        {
            Game.Create(1,"Street Fighter",_genresClient.FindByName("Action"),150,2010),
            Game.Create(2,"Call of Duty",_genresClient.FindByName("War"),140,2011),
            Game.Create(3,"Medal Of Honor",_genresClient.FindByName("War"),250,2015),
            Game.Create(4,"Need For Speed",_genresClient.FindByName("Family"),90,2018),
            Game.Create(5,"Freedom Fighter",_genresClient.FindByName("Action"),170,2019)
        };
    }

    #region Retrieve

    public List<Game> GetGamesList() => _gamesList;

    public Game? FindById(int id) => _gamesList.FirstOrDefault(c => c.Id == id);

    #endregion

    #region Insert

    public void AddGame(string name, int genreId, decimal price, int year)
    {
        var genre = _genresClient.FindById(genreId);

        var newGame = Game.Create(name, genre, price, year);

        _gamesList.Add(newGame);

        //Send New Game To Api Service
    }

    #endregion

    #region Update

    public void UpdateGame(int id,string name, int genreId, decimal price, int year)
    {
        var oldGame = FindById(id);
        var genre = _genresClient.FindById(genreId);

        if (oldGame != null)
        {
            oldGame.ChangeName(name);
            oldGame.ChangeGenre(genre);
            oldGame.SetPrice(price);
            oldGame.SetYear(year);

            //Send Updated Game to Api Service
        }



    }

    #endregion

    #region Delete

    public void DeleteGame(int id)
    {
        var oldGame = FindById(id);

        if (oldGame != null)
        {
            _gamesList.Remove(oldGame);

            //Send Deleted Game To Api Service
        }

    }

    #endregion

}