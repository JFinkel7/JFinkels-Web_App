using System;
using System.ComponentModel.DataAnnotations;
namespace Login_App.ViewModels {

    public class RegisterViewModel {
        /*****Adding Attributes*****/
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Confirmation Does Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
