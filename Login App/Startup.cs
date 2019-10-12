/*** 
    * Software Developer: Denis J-Finkel
    * Project Goal: Create Website With Login User Authorization
    * Tools Used: ASP.NET Core,Entity Framework,Core Identity, SQL-Server
    * HTML,CSS,SCSS, C# Helper Tags 
***/
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Login_App.Models;
using Login_App.Services;
using Login_App.Repository;
using Microsoft.AspNetCore.Identity;

namespace Login_App {
    public class Startup {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) {
            _config = config;

        }
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
            /* Connects To SQL_Server ↓ */
            services.AddDbContextPool<UserDB_Context>(
                options => options.UseSqlServer(_config.GetConnectionString("Default"))
            );
            services.AddTransient<IUser, UserRepository>();
            /* Adds Identity ↓ */
            services.AddIdentity<IdentityUser, IdentityRole>()
            /* Adds Entity Framework ↓ */
            .AddEntityFrameworkStores<UserDB_Context>();

            /* Adds Asp.NetCore Identity Options */
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;

            });
        }

        /* This method gets called by the runtime. Use this method to configure the HTTP request pipeline.*/
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            /* [Enables] Static Content Files (wwwroot) */
            app.UseStaticFiles();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //* [Enables] SQL & Microsoft.EntityFrameworkCore Debugging *
                app.UseDatabaseErrorPage();
            }
            /* [Enables] Authenticaion */
            app.UseAuthentication();
            app.UseMvc(route => {
                route.MapRoute("Default", "{Controller=Home}/{Action=Index}/{id?}");
            });

        }
    }

}
