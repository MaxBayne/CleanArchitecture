using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Genre;
using CleanArchitecture.BlazorApp.DataModels;

namespace CleanArchitecture.BlazorApp.ObjectMapping.AutoMapper.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ViewGenreDto, GenreModel>().ReverseMap();
        CreateMap<ViewGameDto, GameModel>().ReverseMap();
    }
}
