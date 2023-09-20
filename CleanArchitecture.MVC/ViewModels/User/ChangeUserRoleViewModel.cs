using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.User
{
    public class ChangeUserRoleViewModel : BaseViewModel
    {
        public string? Role { get; set; }
    }
}
