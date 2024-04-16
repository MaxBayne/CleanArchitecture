using CleanArchitecture.Blazor.DataModels;

namespace CleanArchitecture.Blazor.Clients.Contracts
{
    public interface IGenresClient
    {
        GameGenre? FindById(int id);
        GameGenre? FindByName(string name);
        List<GameGenre> GetGameGenres();
    }
}
