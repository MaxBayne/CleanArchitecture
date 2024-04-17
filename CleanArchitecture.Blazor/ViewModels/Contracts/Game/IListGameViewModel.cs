namespace CleanArchitecture.Blazor.ViewModels.Contracts.Game;

public interface IListGameViewModel
{
    List<Domain.Entities.Game> GamesList { get; set; }
}