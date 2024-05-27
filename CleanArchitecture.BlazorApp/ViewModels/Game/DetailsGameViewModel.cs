using CleanArchitecture.BlazorApp.DataModels;
using CleanArchitecture.BlazorApp.ViewModels.Abstract;

namespace CleanArchitecture.BlazorApp.ViewModels.Game;

public class DetailsGameViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public GenreModel Genre { get; set; } = new();
    public decimal Price { get; set; }
    public int Year { get; set; }
}
