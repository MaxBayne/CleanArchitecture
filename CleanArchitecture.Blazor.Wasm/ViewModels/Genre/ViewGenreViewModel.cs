using CleanArchitecture.Blazor.Wasm.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.Wasm.ViewModels.Genre;

public class ViewGenreViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
