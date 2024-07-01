using CleanArchitecture.Blazor.Server.DataModels;
using CleanArchitecture.Blazor.Server.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.Server.ViewModels.Game;

public class DetailsGameViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public GenreModel Genre { get; set; } = new();
    public decimal Price { get; set; }
    public int Year { get; set; }
}
