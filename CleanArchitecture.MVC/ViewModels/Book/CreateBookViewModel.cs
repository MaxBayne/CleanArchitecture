using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.Book
{
    public class CreateBookViewModel: BaseViewModel
    {
        public required string? Title { get; set; }
        public string? Description { get; set; }

        
        public required string? Category { get; set; }

        public bool IsActive { get; set; }
    }
}
