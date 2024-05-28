using CleanArchitecture.BlazorApp.DataModels;

namespace CleanArchitecture.BlazorApp.ApiClients.Contracts;

public interface IGenresClient
{
    GenreModel? FindById(int id);
    GenreModel? FindByName(string name);
    List<GenreModel> GetGameGenres();
}

