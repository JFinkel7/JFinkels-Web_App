using System.Collections.Generic;
using Login_App.Models;
namespace Login_App.Services {
   public interface IUser {

        Users GetUser(int? id);
        IEnumerable<Users> GetUsers { get; }
        Users Add(Users user);
        Users Update(Users user);
        Users Delete(int? id);

    }
}
