using CleanArchitecture.BlazorApp.DataModels;
using CleanArchitecture.BlazorApp.ViewModels.Abstract;

namespace CleanArchitecture.BlazorApp.ViewModels.Game;

public class ListGameViewModel : BaseViewModel
{
    public List<GameModel> GamesList { get; set; } = new();
}
