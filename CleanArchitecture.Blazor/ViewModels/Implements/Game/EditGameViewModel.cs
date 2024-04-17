using CleanArchitecture.Blazor.ViewModels.Abstract;
using CleanArchitecture.Blazor.ViewModels.Contracts.Game;

namespace CleanArchitecture.Blazor.ViewModels.Implements.Game
{
    public class EditGameViewModel : BaseViewModel, IEditGameViewModel
    {
        public Domain.Entities.Game? UpdatedGame { get; set; } = null!;

        public List<Domain.Entities.Genre>? Genres { get; set; }
    }
}
