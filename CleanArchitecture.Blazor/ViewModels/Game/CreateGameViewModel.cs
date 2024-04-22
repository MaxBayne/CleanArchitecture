using CleanArchitecture.Blazor.DataModels;
using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.Game
{
    public class CreateGameViewModel : BaseViewModel
    {
        public GameModel CreatedGame { get; set; }
        public List<GenreModel> GenresList { get; set; } = null!;
    }
}
