using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Blazor.Server.DataModels;
using CleanArchitecture.Blazor.Server.ViewEnums;
using CleanArchitecture.Blazor.Server.ViewModels.Abstract;

namespace CleanArchitecture.Blazor.Server.ViewModels.Game;

public class CreateGameViewModel : BaseViewModel
{

    [Required(ErrorMessage = "Name Field is Required")] 
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Genre Field is Required")] 
    public int GenreId { get; set; } = -1;

    [Required(ErrorMessage = "Price Field is Required")]
    [Range(1, 1000,ErrorMessage = "Price Range will be between 1 : 1000")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Year Field is Required")]
    public int Year { get; set; }

    public bool UseApi { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public GameRateEnum Rate { get; set; }

    
    public List<GenreModel> GenresList { get; set; } = null!;

}
