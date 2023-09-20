using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.User
{
    public class CreateUserViewModel: BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; }

        public string Email { get; set; }

        public bool IsEnabled { get; set; }

        
    }
}
