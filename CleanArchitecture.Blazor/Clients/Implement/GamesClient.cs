using CleanArchitecture.Blazor.Clients.Abstract;
using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Blazor.DataModels;

namespace CleanArchitecture.Blazor.Clients.Implement;



public class GamesClient : BaseClient, IGamesClient
{
    private readonly List<GameCatalog> _gameCatalogs;

    public GamesClient()
    {
        var genresClient = new GenresClient();

        _gameCatalogs = new List<GameCatalog>()
        {
            new()
            {
                Id = 1,
                Name = "Street Figher",
                Genre =genresClient.FindByName("Action")!,
                Price = 150,
                Year = 2010
            },
            new()
            {
                Id = 2,
                Name = "Call of Duty",
                Genre = genresClient.FindByName("Role")!,
                Price = 140,
                Year = 2011
            },
            new()
            {
                Id = 3,
                Name = "Medal Of Honor",
                Genre = genresClient.FindByName("War")!,
                Price = 250,
                Year = 2015
            },
            new()
            {
                Id = 4,
                Name = "Zomaa",
                Genre = genresClient.FindByName("Family")!,
                Price = 90,
                Year = 2018
            },
            new()
            {
                Id = 5,
                Name = "Freedom Figher",
                Genre = genresClient.FindByName("Action")!,
                Price = 170,
                Year = 2019
            }
        };
    }

    #region Retrieve

    public List<GameCatalog> GetGameCatalogs() => _gameCatalogs;

    public GameCatalog? FindById(int id) => _gameCatalogs.FirstOrDefault(c => c.Id == id);

    #endregion

    #region Insert

    public void AddGame(GameCatalog game)
    {
        _gameCatalogs.Add(game);
    }

    #endregion

    #region Update

    public void UpdateGame(GameCatalog updatedGame)
    {
        var oldGame = FindById(updatedGame.Id);

        if (oldGame != null)
        {
            oldGame.Name = updatedGame.Name;
            oldGame.Genre = updatedGame.Genre;
            oldGame.Price = updatedGame.Price;
            oldGame.Year = updatedGame.Year;
        }

    }

    #endregion

    #region Delete

    public void DeleteGame(int id)
    {
        var oldGame = FindById(id);

        if (oldGame != null)
        {
            _gameCatalogs.Remove(oldGame);
        }

    }

    #endregion

}