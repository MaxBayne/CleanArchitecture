namespace CleanArchitecture.Blazor.Models
{
    public class GameCatalogModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
