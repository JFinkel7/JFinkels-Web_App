using Login_App.Models;
using Login_App.Services;
using System.Collections.Generic;
namespace Login_App.Repository {
    public class UserRepository : IUser {
        private readonly UserDB_Context dbContext;
        public UserRepository(UserDB_Context dbContext) {
            this.dbContext = dbContext;
        }
        public IEnumerable<Users> GetUsers => dbContext.Users;

        public Users GetUser(int? id) {
            return (this.dbContext.Users.Find(id));
        }
        public Users Add(Users user) {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public Users Delete(int? id) {
            Users userEntity = this.dbContext.Users.Find(id);
            dbContext.Users.Remove(userEntity);
            dbContext.SaveChanges();
            return userEntity;
        }

        public Users Update(Users user) {
            Users userEntity = this.dbContext.Users.Find(user);
            dbContext.Users.Update(userEntity);
            return (userEntity);
        }
    }
}
