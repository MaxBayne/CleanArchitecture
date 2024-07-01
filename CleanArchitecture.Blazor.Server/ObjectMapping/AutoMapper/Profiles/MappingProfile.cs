using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Genre;
using CleanArchitecture.Blazor.Server.DataModels;

namespace CleanArchitecture.Blazor.Server.ObjectMapping.AutoMapper.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ViewGenreDto, GenreModel>().ReverseMap();
        CreateMap<ViewGameDto, GameModel>().ReverseMap();
    }
}
