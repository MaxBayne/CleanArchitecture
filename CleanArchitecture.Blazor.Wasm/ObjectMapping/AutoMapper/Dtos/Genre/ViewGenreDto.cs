using CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Abstract;

namespace CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Dtos.Genre
{
    public class ViewGenreDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
