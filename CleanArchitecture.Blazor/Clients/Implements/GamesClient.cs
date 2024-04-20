using CleanArchitecture.Blazor.Clients.Abstract;
using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Blazor.DataModels;


namespace CleanArchitecture.Blazor.Clients.Implements;


// ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
public class GamesClient : BaseClient, IGamesClient
{
    private readonly List<GameModel> _gamesList;
    private readonly IGenresClient _genresClient;

    public GamesClient(IGenresClient genresClient)
    {
        _genresClient = genresClient;
        _gamesList = new List<GameModel>()
        {
            new GameModel{Id=1,Name="Street Fighter",Genre=_genresClient.FindByName("Action")!,Price=150,Year=2010},
            new GameModel{Id=2,Name="Call of Duty",Genre=_genresClient.FindByName("War")!,Price=46,Year=2008},
            new GameModel{Id=3,Name="Medal Of Honor",Genre=_genresClient.FindByName("War")!,Price=98,Year=2019},
            new GameModel{Id=4,Name="Need For Speed",Genre=_genresClient.FindByName("Family")!,Price=870,Year=2022},
            new GameModel{Id=5,Name="Freedom Fighter",Genre=_genresClient.FindByName("Action")!,Price=450,Year=2018}
        };
    }

    #region Retrieve

    public List<GameModel> GetGamesList() => _gamesList;

    public GameModel? FindById(int id) => _gamesList.FirstOrDefault(c => c.Id == id);

    #endregion

    #region Insert

    public void AddGame(string name, int genreId, decimal price, int year)
    {
        var genre = _genresClient.FindById(genreId);

        var newGame = new GameModel() 
        {
            Name=name,
            Genre=genre!,
            Price= price,
            Year=year 
        };

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
            oldGame.Name=name;
            oldGame.Genre=genre!;
            oldGame.Price=price;
            oldGame.Year=year;

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