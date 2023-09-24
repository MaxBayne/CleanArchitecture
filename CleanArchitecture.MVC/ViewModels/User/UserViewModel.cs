using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.User
{
    public class UserViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsEnabled { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
