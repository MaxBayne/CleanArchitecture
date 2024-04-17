using CleanArchitecture.Blazor.ViewModels.Abstract;
using CleanArchitecture.Blazor.ViewModels.Contracts.Game;

namespace CleanArchitecture.Blazor.ViewModels.Implements.Game
{
    public class DetailsGameViewModel : BaseViewModel, IDetailsGameViewModel
    {
        public Domain.Entities.Game? GameDetails { get; set; }
    }
}
