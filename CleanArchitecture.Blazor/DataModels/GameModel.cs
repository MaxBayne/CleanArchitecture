using CleanArchitecture.Blazor.DataModels.Abstract;

namespace CleanArchitecture.Blazor.DataModels
{
    public class GameModel:BaseDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreModel Genre { get; set; } = new();
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
