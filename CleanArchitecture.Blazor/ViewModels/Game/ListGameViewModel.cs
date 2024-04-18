using CleanArchitecture.Blazor.DataModels;
using CleanArchitecture.Blazor.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.ViewModels.Game
{
    public class ListGameViewModel : BaseViewModel
    {
        public List<GameModel> GamesList { get; set; } = new();
    }
}
