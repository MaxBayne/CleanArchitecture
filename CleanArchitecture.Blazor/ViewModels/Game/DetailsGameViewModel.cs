using CleanArchitecture.Blazor.DataModels;
using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.Game
{
    public class DetailsGameViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public GenreModel Genre { get; set; } = new();
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
