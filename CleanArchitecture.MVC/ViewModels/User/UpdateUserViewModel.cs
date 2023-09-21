using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.User
{
    public class UpdateUserViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
