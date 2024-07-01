using CleanArchitecture.Blazor.Server.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.Server.ViewModels.Genre;

public class ViewGenreViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
