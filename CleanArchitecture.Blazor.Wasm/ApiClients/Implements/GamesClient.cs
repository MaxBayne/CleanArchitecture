using AutoMapper;
using CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Blazor.Wasm.ApiClients.Abstract;
using CleanArchitecture.Blazor.Wasm.ApiClients.Contracts;
using CleanArchitecture.Blazor.Wasm.DataModels;
using System.Net.Http.Json;

namespace CleanArchitecture.Blazor.Wasm.ApiClients.Implements;

public class GamesClient : BaseClient, IGamesClient
{
    private readonly IGenresClient _genresClient;
    private readonly ILogger<GamesClient> _logger;
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;

    public GamesClient(ILogger<GamesClient> logger, IMapper mapper, IGenresClient genresClient, HttpClient httpClient)
    {
        _logger = logger;
        _mapper = mapper;
        _httpClient = httpClient;
        _genresClient = genresClient;
    }

    #region Retrieve

    public async Task<List<GameModel>> GetGamesListAsync()
    {
        List<GameModel> gamesList = new();

        try
        {
            //try to fetch games list from api if fail then will use memory version
            var gamesFromApi = await _httpClient.GetFromJsonAsync<List<ViewGameDto>>("Game");

            if (gamesFromApi != null)
            {
                //convert from dto to model
                gamesList = _mapper.Map<List<GameModel>>(gamesFromApi);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return gamesList;
    }

    public async Task<GameModel?> FindByIdAsync(int id)
    {
        GameModel? game = null;

        try
        {
            var fromApi = await _httpClient.GetFromJsonAsync<ViewGameDto>($"Game/{id}");

            if (fromApi != null)
            {
                //convert from dto to model
                game = _mapper.Map<GameModel>(fromApi);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return game;
    }


    #endregion

    #region Insert

    public async Task AddGameAsync(string name, int genreId, decimal price, int year)
    {
        try
        {
            var newGameDto = new CreateGameDto()
            {
                Name = name,
                GenreId = genreId,
                Price = price,
                Year = year
            };

            var post = await _httpClient.PostAsJsonAsync("Game", newGameDto);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    #endregion

    #region Update

    public async Task UpdateGameAsync(int id, string name, int genreId, decimal price, int year)
    {
        try
        {
            var editGameDto = new UpdateGameDto()
            {
                Name = name,
                GenreId = genreId,
                Price = price,
                Year = year
            };

            var put = await _httpClient.PutAsJsonAsync($"Game/{id}", editGameDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

    }

    #endregion

    #region Delete

    public async Task DeleteGameAsync(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"Game/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    #endregion

}




