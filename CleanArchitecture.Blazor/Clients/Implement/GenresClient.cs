using CleanArchitecture.Blazor.Clients.Abstract;
using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Blazor.DataModels;

namespace CleanArchitecture.Blazor.Clients.Implement;



public class GenresClient : BaseClient, IGenresClient
{
    private readonly List<GameGenre> _gameGenres;

    public GenresClient()
    {
        _gameGenres = new List<GameGenre>()
        {
            new()
            {
                Id = 1,
                Name = "Action"
            },
            new()
            {
                Id = 2,
                Name = "War"
            },
            new()
            {
                Id = 3,
                Name = "Family"
            },
            new()
            {
                Id = 4,
                Name = "Drama"
            }
        };
    }

    #region Retrieve

    public List<GameGenre> GetGameGenres() => _gameGenres;

    public GameGenre? FindById(int id) => _gameGenres.FirstOrDefault(c => c.Id == id);

    public GameGenre? FindByName(string name) => _gameGenres.FirstOrDefault(c => c.Name == name);
    #endregion
}