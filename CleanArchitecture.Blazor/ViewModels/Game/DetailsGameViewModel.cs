using CleanArchitecture.Blazor.DataModels;
using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.Game
{
    public class DetailsGameViewModel : BaseViewModel
    {
        public GameModel? GameDetails { get; set; } = new();
    }
}
