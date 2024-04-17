namespace CleanArchitecture.Blazor.ViewModels.Contracts.Game;

public interface IDetailsGameViewModel
{
    Domain.Entities.Game? GameDetails { get; set; }
}