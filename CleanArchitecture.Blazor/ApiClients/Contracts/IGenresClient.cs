using CleanArchitecture.Blazor.DataModels;

namespace CleanArchitecture.Blazor.ApiClients.Contracts;

public interface IGenresClient
{
    GenreModel? FindById(int id);
    GenreModel? FindByName(string name);
    List<GenreModel> GetGameGenres();
}

