using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.GameCatalog
{
    public class ViewGameCatalogViewModel : BaseViewModel
    {
        public List<DataModels.GameCatalog> GameCatalogs { get; set; }
    }
}
