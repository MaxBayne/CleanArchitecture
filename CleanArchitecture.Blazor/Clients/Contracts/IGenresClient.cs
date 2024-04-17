using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Blazor.Clients.Contracts
{
    public interface IGenresClient
    {
        Genre? FindById(int id);
        Genre? FindByName(string name);
        List<Genre> GetGameGenres();
    }
}
