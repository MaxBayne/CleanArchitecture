using CleanArchitecture.Blazor.Clients.Abstract;
using CleanArchitecture.Blazor.DataModels;
using CleanArchitecture.Blazor.ViewModels.GameCatalog;

namespace CleanArchitecture.Blazor.Clients;

public class GamesClient : BaseClient
{
    private readonly List<GameCatalog> _gameCatalogs;

    public GamesClient()
    {
        _gameCatalogs = new List<GameCatalog>()
        {
            new()
            {
                Id = 1,
                Name = "Street Figher",
                Genre = "Action",
                Price = 150,
                Year = 2010
            },
            new()
            {
                Id = 2,
                Name = "Call of Duty",
                Genre = "Role",
                Price = 140,
                Year = 2011
            },
            new()
            {
                Id = 3,
                Name = "Medal Of Honor",
                Genre = "War",
                Price = 250,
                Year = 2015
            },
            new()
            {
                Id = 4,
                Name = "Zomaa",
                Genre = "Family",
                Price = 90,
                Year = 2018
            },
            new()
            {
                Id = 5,
                Name = "Freedom Figher",
                Genre = "Action",
                Price = 170,
                Year = 2019
            }
        };
    }



    public List<GameCatalog> GetGameCatalogs() => _gameCatalogs;

    public GameCatalog? FindById(int id)=> _gameCatalogs.FirstOrDefault(c => c.Id == id);
    
}