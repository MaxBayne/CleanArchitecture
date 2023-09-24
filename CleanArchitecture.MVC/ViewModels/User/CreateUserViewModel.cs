using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.User
{
    public class CreateUserViewModel: BaseViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Role { get; set; }

        public bool IsEnabled { get; set; }
        
    }
}
