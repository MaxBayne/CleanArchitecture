using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Persistence.Repositories
{
    public interface IGameRepository : IGenericRepository<Game, int>
    {
        Task<List<Game>> Get_All_Games_With_Genre_Async();
    }
}
