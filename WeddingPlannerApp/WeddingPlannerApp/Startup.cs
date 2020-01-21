using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Net.Http;
using WeddingPlannerApp.Models;

[assembly: OwinStartupAttribute(typeof(WeddingPlannerApp.Startup))]
namespace WeddingPlannerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
    
            ApplicationDbContext context = new ApplicationDbContext();
            ConfigureAuth(app);
            CreateRolesAndUsers(context);
        }
        private void CreateRolesAndUsers(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                var user = new ApplicationUser();
                user.UserName = "houacha";
                user.Email = "houacha@gmail.com";
                string userPWD = "Hc227100!";
                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("Vendor"))
            {
                var role = new IdentityRole();
                role.Name = "Vendor";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Couple"))
            {
                var role = new IdentityRole();
                role.Name = "Couple";
                roleManager.Create(role);
            }
        }
    }
}
