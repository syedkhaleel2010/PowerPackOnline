using System.ComponentModel.DataAnnotations;

namespace Identity.API.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
