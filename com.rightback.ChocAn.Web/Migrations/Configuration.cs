namespace com.rightback.ChocAn.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<com.rightback.ChocAn.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(com.rightback.ChocAn.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            string[] roles = { "Manager", "Operator" };
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            for (int i = 0; i < roles.Length; i++)
            {
                if (RoleManager.RoleExists(roles[i]) == false)
                {
                    RoleManager.Create(new IdentityRole(roles[i]));
                }
            }

            // user

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            UserManager.Create(new ApplicationUser
            {
                UserName = "magid.yahya@hotmail.com",
                Email = "magid.yahya@hotmail.com",
                EmailConfirmed = true,
                }, "123456");
                UserManager.Create(new ApplicationUser
                {
                    UserName = "beribener@hotmail.com",
                    Email = "beribener@hotmail.com",
                    EmailConfirmed = true,
                }, "123456");

            var magid = context.Users.Where(e => e.Email == "magid.yahya@hotmail.com").FirstOrDefault() ;
            var beri = context.Users.Where(e => e.Email == "beribener@hotmail.com").FirstOrDefault();
            UserManager.AddToRole(magid.Id, roles[0]);
            UserManager.AddToRole(beri.Id, roles[1]);

            
        }
    }
}
