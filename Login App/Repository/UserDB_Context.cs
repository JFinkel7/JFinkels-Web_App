using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login_App.Models {
    public class UserDB_Context : IdentityDbContext {
        public UserDB_Context(DbContextOptions<UserDB_Context> options) : base(options) {

        }
        public DbSet<Users> Users { get; set; }
    }
}
