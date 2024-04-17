using CleanArchitecture.Blazor.ViewModels.Abstract;
using CleanArchitecture.Blazor.ViewModels.Contracts.Game;

namespace CleanArchitecture.Blazor.ViewModels.Implements.Game
{
    public class ListGameViewModel : BaseViewModel, IListGameViewModel
    {
        public List<Domain.Entities.Game> GamesList { get; set; } = null!;
    }
}
