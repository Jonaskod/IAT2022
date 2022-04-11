using System.ComponentModel.DataAnnotations;

namespace IAT2022.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// ViewModel for login page // home controller
        /// </summary>
        [Required]


        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

    }
}
