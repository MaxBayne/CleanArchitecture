using CleanArchitecture.Blazor.Clients.Abstract;
using CleanArchitecture.Blazor.Clients.Contracts;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Blazor.Clients.Implements;



public class GenresClient : BaseClient, IGenresClient
{
    private readonly List<Genre> _gameGenres;

    public GenresClient()
    {
        _gameGenres = new List<Genre>
        {
            Genre.Create(1, "Action"),
            Genre.Create(2, "War"),
            Genre.Create(3, "Family"),
            Genre.Create(4, "Tricks")
        };
    }

    #region Retrieve

    public List<Genre> GetGameGenres() => _gameGenres;

    public Genre? FindById(int id) => _gameGenres.FirstOrDefault(c => c.Id == id);

    public Genre? FindByName(string name) => _gameGenres.FirstOrDefault(c => c.Name == name);
    #endregion
}