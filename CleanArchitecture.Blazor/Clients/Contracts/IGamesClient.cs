using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Blazor.Clients.Contracts
{
    public interface IGamesClient
    {
        /// <summary>
        /// Create New Game
        /// </summary>
        /// <param name="game"></param>
        void AddGame(Game game);

        /// <summary>
        /// Update Existing Game
        /// </summary>
        /// <param name="updatedGame"></param>
        void UpdateGame(Game updatedGame);

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
