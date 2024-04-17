namespace CleanArchitecture.Blazor.ViewModels.Contracts.Game
{
    public interface ICreateGameViewModel
    {
        Domain.Entities.Game CreatedGame { get; set; }
        List<Domain.Entities.Genre>? Genres { get; set; }
    }
}

