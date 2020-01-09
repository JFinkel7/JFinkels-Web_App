using Login_App.Models;
using Login_App.Services;
using Login_App.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Login_App.Controllers.Home {
    public class HomeController : Controller {
        private readonly Users users = new Users();
        private readonly IUser _user;
        public HomeController(IUser user) {
            this._user = user;
        }
        [HttpGet]
        public IActionResult Index() {
            return View(_user.GetUsers);

        }

      
        [HttpGet]
        public IActionResult About() {
            return View();

        }

        
        [HttpGet]
        public IActionResult HowIStarted() {
            return View();

        }

        
        [HttpGet]
        public IActionResult Resume() {
            return View();

        }

    
    }// END OF CLASS
}
