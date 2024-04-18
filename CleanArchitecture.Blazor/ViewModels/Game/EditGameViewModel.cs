using CleanArchitecture.Blazor.DataModels;
using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.Game
{
    public class EditGameViewModel : BaseViewModel
    {
        public GameModel? UpdatedGame { get; set; } = null!;
        public List<GenreModel> GenresList { get; set; } = null!;
    }
}
