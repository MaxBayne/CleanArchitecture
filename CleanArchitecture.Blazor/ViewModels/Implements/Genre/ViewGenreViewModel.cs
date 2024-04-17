using CleanArchitecture.Blazor.ViewModels.Abstract;
using CleanArchitecture.Blazor.ViewModels.Contracts.Genre;

namespace CleanArchitecture.Blazor.ViewModels.Implements.Genre
{
    public class ViewGenreViewModel : BaseViewModel, IViewGenreViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
