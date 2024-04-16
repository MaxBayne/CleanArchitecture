using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.GameGenre
{
    public class ViewGameGenreViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
