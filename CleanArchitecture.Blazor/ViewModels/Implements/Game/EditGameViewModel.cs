using CleanArchitecture.Blazor.ViewModels.Abstract;
using CleanArchitecture.Blazor.ViewModels.Contracts.Game;

namespace CleanArchitecture.Blazor.ViewModels.Implements.Game
{
    public class EditGameViewModel : BaseViewModel, IEditGameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        public bool IsExist { get; set; }


        public List<Domain.Entities.Genre>? Genres { get; set; }
    }
}
