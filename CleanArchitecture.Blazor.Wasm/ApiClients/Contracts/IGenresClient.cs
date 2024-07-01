using CleanArchitecture.Blazor.Wasm.DataModels;

namespace CleanArchitecture.Blazor.Wasm.ApiClients.Contracts;

public interface IGenresClient
{
    GenreModel? FindById(int id);
    GenreModel? FindByName(string name);
    List<GenreModel> GetGameGenres();
}

