using CleanArchitecture.Blazor.Wasm.DataModels;
using CleanArchitecture.Blazor.Wasm.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.Wasm.ViewModels.Game;

public class DetailsGameViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public GenreModel Genre { get; set; } = new();
    public decimal Price { get; set; }
    public int Year { get; set; }
}
