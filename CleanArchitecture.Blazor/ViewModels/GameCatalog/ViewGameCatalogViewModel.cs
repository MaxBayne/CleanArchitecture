using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.GameCatalog
{
    public class ViewGameCatalogViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
