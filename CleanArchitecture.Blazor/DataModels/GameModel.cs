using CleanArchitecture.Blazor.DataModels.Abstract;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Blazor.DataModels
{
    public class GameModel:BaseDataModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreModel Genre { get; set; } = new();
        public decimal Price { get; set; }

        [Range(2000,2050)]
        public int Year { get; set; }
    }
}
