using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Blazor.Server.DataModels;
using CleanArchitecture.Blazor.Server.DataModels.Abstract;

namespace CleanArchitecture.Blazor.Server.DataModels;

public class GameModel:BaseDataModel
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public GenreModel Genre { get; set; } = new();

    public int GenreId { get; set; }

    [Range(1,0)]
    public decimal Price { get; set; }
    public int Year { get; set; }
}
