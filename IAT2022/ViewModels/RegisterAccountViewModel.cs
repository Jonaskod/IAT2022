using System.ComponentModel.DataAnnotations;

namespace IAT2022.ViewModels
{
    public class RegisterAccountViewModel
    {
        /// <summary>
        /// Input from an interface, props for setting input values.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords didnt match!")]
        public string ConfirmPassword { get; set; }
    }
}
