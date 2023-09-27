using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.ViewModels.Account
{
    public class RegisterViewModel : BaseViewModel
    {
        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string UserPassword { get; set; }

      
    }
}
