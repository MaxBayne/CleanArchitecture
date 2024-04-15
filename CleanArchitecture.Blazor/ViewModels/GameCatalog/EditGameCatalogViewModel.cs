using CleanArchitecture.Blazor.DataModels;
using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.GameCatalog
{
    public class EditGameCatalogViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        public List<GameGenre>? Genres { get; set; }
    }
}
