using CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Abstract;


namespace CleanArchitecture.Blazor.Wasm.ObjectMapping.AutoMapper.Dtos.Game
{
    public class CreateGameDto: BaseDto
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
