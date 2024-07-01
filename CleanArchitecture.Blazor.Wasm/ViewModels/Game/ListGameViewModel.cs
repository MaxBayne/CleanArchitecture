using CleanArchitecture.Blazor.Wasm.DataModels;
using CleanArchitecture.Blazor.Wasm.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.Wasm.ViewModels.Game;

public class ListGameViewModel : BaseViewModel
{
    public List<GameModel> GamesList { get; set; } = new();
}
