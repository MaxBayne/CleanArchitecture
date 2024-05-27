using System.ComponentModel.DataAnnotations;
using CleanArchitecture.BlazorApp.DataModels;
using CleanArchitecture.BlazorApp.DataModels.Abstract;

namespace CleanArchitecture.BlazorApp.DataModels;

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
