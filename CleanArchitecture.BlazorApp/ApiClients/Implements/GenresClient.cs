using CleanArchitecture.BlazorApp.ApiClients.Abstract;
using CleanArchitecture.BlazorApp.ApiClients.Contracts;
using CleanArchitecture.BlazorApp.DataModels;

namespace CleanArchitecture.BlazorApp.ApiClients.Implements;



public class GenresClient : BaseClient, IGenresClient
{
    private readonly List<GenreModel> _gameGenres;
    private readonly HttpClient _httpClient;

    public GenresClient(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _gameGenres = new List<GenreModel>
        {
            new GenreModel{ Id=1,Name="Action"},
            new GenreModel{ Id=2,Name="War"},
            new GenreModel{ Id=3,Name="Family"},
            new GenreModel{ Id=4,Name="Tricks"}
        };
        
    }

    #region Retrieve

    public List<GenreModel> GetGameGenres() => _gameGenres;

    public GenreModel? FindById(int id) => _gameGenres.FirstOrDefault(c => c.Id == id);

    public GenreModel? FindByName(string name) => _gameGenres.FirstOrDefault(c => c.Name == name);
    #endregion
}