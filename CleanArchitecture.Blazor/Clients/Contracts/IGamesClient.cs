using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Blazor.Clients.Contracts
{
    public interface IGamesClient
    {
        /// <summary>
        /// Create New Game
        /// </summary>
        void AddGame(string name,int genreId,decimal price,int year);

        /// <summary>
        /// Update Existing Game
        /// </summary>
        void UpdateGame(int id,string name, int genreId, decimal price, int year);

        /// <summary>
        /// Delete Existing Game
        /// </summary>
        /// <param name="id"></param>
        void DeleteGame(int id);

        /// <summary>
        /// Search For Game VIA Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Game? FindById(int id);

        /// <summary>
        /// Get List of Games
        /// </summary>
        /// <returns></returns>
        List<Game> GetGamesList();

    }
}
