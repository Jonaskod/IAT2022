﻿using System.ComponentModel.DataAnnotations;

namespace IAT2022.ViewModels
{
    public class PasswordResetViewModel
    {
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
        public string? Token { get; set; }
       
    }
}
