using CleanArchitecture.BlazorApp.ViewModels.Abstract;

namespace CleanArchitecture.BlazorApp.ViewModels.Genre;

public class ViewGenreViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
