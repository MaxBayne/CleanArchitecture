using CleanArchitecture.BlazorApp.DataModels;
using CleanArchitecture.BlazorApp.ViewModels.Abstract;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.BlazorApp.ViewModels.Game;

public class EditGameViewModel : BaseViewModel
{
    public int Id { get; set; } = 0;

    [Required(ErrorMessage = "Name Field is Required")]
    public string? Name { get; set; }

    [Required]
    public int GenreId { get; set; }

    [Required(ErrorMessage = "Price Field is Required")]
    [Range(1, 1000, ErrorMessage = "Price Range will be between 1 : 1000")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Year Field is Required")]
    public int Year { get; set; }


    public List<GenreModel> GenresList { get; set; } = null!;
}
