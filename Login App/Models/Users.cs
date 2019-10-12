using System.ComponentModel.DataAnnotations;

namespace Login_App.Models {
    public class Users {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
