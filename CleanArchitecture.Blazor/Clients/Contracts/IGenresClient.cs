using CleanArchitecture.Blazor.DataModels;

namespace CleanArchitecture.Blazor.Clients.Contracts
{
    public interface IGenresClient
    {
        GenreModel? FindById(int id);
        GenreModel? FindByName(string name);
        List<GenreModel> GetGameGenres();
    }
}
