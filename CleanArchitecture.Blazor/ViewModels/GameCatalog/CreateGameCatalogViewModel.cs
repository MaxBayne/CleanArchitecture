using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.GameCatalog
{
    public class CreateGameCatalogViewModel : BaseViewModel
    {
        public DataModels.GameCatalog CreatedGameCatalog { get; set; } = null!;

        public List<DataModels.GameGenre>? Genres { get; set; }
    }
}
