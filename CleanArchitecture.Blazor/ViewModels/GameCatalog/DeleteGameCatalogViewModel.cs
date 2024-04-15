using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.GameCatalog
{
    public class DeleteGameCatalogViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
