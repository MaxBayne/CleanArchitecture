using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.GameCatalog
{
    public class EditGameCatalogViewModel : BaseViewModel
    {
        public DataModels.GameCatalog? UpdatedGameCatalog { get; set; } = null!;

        public List<DataModels.GameGenre>? Genres { get; set; }
    }
}
