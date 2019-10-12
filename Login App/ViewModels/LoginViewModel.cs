using System.ComponentModel.DataAnnotations;

namespace Login_App.ViewModels {
    public class LoginViewModel {
        /*****Adding Attributes*****/
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /*****Used For CheckBox*****/
        [Required]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
