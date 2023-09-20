using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.User
{
    public class DeleteUserViewModel : BaseViewModel
    {
        public int UserId { get; set; }
    }
}
