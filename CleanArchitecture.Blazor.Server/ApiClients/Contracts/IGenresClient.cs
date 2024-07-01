using CleanArchitecture.Blazor.Server.DataModels;

namespace CleanArchitecture.Blazor.Server.ApiClients.Contracts;

public interface IGenresClient
{
    GenreModel? FindById(int id);
    GenreModel? FindByName(string name);
    List<GenreModel> GetGameGenres();
}

