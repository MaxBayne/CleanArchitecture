using CleanArchitecture.Blazor.Server.DataModels;
using CleanArchitecture.Blazor.Server.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.Server.ViewModels.Game;

public class ListGameViewModel : BaseViewModel
{
    public List<GameModel> GamesList { get; set; } = new();
}
