using AutoMapper;
using CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Dtos.Game;
using CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Dtos.Genre;
using CleanArchitecture.Blazor.Wasm.DataModels;

namespace CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ViewGenreDto, GenreModel>().ReverseMap();
        CreateMap<ViewGameDto, GameModel>().ReverseMap();
    }
}
