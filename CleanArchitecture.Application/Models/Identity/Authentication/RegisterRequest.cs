using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Models.Identity.Authentication
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
