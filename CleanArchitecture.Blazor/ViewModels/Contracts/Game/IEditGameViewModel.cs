namespace CleanArchitecture.Blazor.ViewModels.Contracts.Game;

public interface IEditGameViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GenreId { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }

    public bool IsExist { get; set; }

    List<Domain.Entities.Genre>? Genres { get; set; }
}