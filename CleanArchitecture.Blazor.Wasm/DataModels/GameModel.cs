using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Blazor.Wasm.DataModels;
using CleanArchitecture.Blazor.Wasm.DataModels.Abstract;

namespace CleanArchitecture.Blazor.Wasm.DataModels;

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
