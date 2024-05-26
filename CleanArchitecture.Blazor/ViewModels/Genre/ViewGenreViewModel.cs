using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.Genre
{
    public class ViewGenreViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
