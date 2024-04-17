using CleanArchitecture.Blazor.ViewModels.Abstract;
using CleanArchitecture.Blazor.ViewModels.Contracts.Game;

namespace CleanArchitecture.Blazor.ViewModels.Implements.Game
{
    public class DeleteGameViewModel : BaseViewModel, IDeleteGameViewModel
    {
        public int Id { get; set; }
    }
}
