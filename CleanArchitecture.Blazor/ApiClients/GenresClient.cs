﻿using CleanArchitecture.Blazor.ApiClients.Abstract;
using CleanArchitecture.Blazor.DataModels;

namespace CleanArchitecture.Blazor.ApiClients;

public class GenresClient : BaseClient
{
    private readonly List<GameGenre> _gameGenres;

    public GenresClient()
    {
        _gameGenres = new List<GameGenre>()
        {
            new()
            {
                Id = 1,
                Name = "Action"
            },
            new()
            {
                Id = 2,
                Name = "War"
            },
            new()
            {
                Id = 3,
                Name = "Family"
            },
            new()
            {
                Id = 4,
                Name = "Drama"
            }
        };
    }

    public List<GameGenre> GetGameGenres() => _gameGenres;

    public GameGenre? FindById(int id)=> _gameGenres.FirstOrDefault(c => c.Id == id);
    

}