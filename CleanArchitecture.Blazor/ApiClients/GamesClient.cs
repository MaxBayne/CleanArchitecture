using CleanArchitecture.Blazor.ApiClients.Abstract;
using CleanArchitecture.Blazor.Models;

namespace CleanArchitecture.Blazor.ApiClients;

public class GamesClient : BaseClient
{
    private readonly List<GameCatalogModel> _gameCatalogs;

    public GamesClient()
    {
        _gameCatalogs = new List<GameCatalogModel>()
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
                Genre = "Action",
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

    public List<GameCatalogModel> GetGameCatalogs() => _gameCatalogs;

}