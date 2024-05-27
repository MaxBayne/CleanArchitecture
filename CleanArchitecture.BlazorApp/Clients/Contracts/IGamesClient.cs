using CleanArchitecture.BlazorApp.DataModels;

namespace CleanArchitecture.BlazorApp.Clients.Contracts;

public interface IGamesClient
{
    /// <summary>
    /// Create New Game
    /// </summary>
    Task AddGameAsync(string name,int genreId,decimal price,int year);

    /// <summary>
    /// Update Existing Game
    /// </summary>
    Task UpdateGameAsync(int id,string name, int genreId, decimal price, int year);

    /// <summary>
    /// Delete Existing Game
    /// </summary>
    /// <param name="id"></param>
    Task DeleteGameAsync(int id);

    /// <summary>
    /// Search For Game VIA Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<GameModel?> FindByIdAsync(int id);

    /// <summary>
    /// Get List of Games From Api if not exist then return the memory version
    /// </summary>
    /// <returns></returns>
    Task<List<GameModel>> GetGamesListAsync();

}
