using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.User
{
    public class ChangeUserAvailabilityViewModel : BaseViewModel
    {
        public bool? IsEnabled { get; set; }
    }
}
