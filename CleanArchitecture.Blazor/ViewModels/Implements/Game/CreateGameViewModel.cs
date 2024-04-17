using CleanArchitecture.Blazor.ViewModels.Abstract;
using CleanArchitecture.Blazor.ViewModels.Contracts.Game;

namespace CleanArchitecture.Blazor.ViewModels.Implements.Game
{
    public class CreateGameViewModel : BaseViewModel, ICreateGameViewModel
    {
        public Domain.Entities.Game CreatedGame { get; set; } = null!;

        public List<Domain.Entities.Genre>? Genres { get; set; }
    }
}
