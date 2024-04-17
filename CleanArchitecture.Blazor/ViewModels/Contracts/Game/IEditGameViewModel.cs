namespace CleanArchitecture.Blazor.ViewModels.Contracts.Game;

public interface IEditGameViewModel
{
    Domain.Entities.Game? UpdatedGame { get; set; }
    List<Domain.Entities.Genre>? Genres { get; set; }
}