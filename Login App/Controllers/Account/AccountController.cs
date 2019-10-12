using Microsoft.AspNetCore.Mvc;
using Login_App.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Login_App.Controllers.Account {
    public class AccountController : Controller {
        /******Configuring Our Instance Variables For Our Constructor******/
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private const string INVALID_LOGIN = "Login Is Invalid";
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registration() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel registerModel) {
            if (ModelState.IsValid) {
                var user = new IdentityUser { UserName = registerModel.Email, Email = registerModel.Email };
                /*The Password Is Hashed And Secured Within The Database*/
                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded) {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return (RedirectToAction("Index", "Home"));
                }

                foreach (var error in result.Errors) {
                    // Adds A Model Error
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            /* After User Is Signed Out We Redirect Back To Home Page */
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel) {
            if (ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
                    loginModel.Password, loginModel.RememberMe, false);

                if (result.Succeeded) {
                    return (RedirectToAction("Index", "Home"));
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return View(loginModel);
        }
    }
}
