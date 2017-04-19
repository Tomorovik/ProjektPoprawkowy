using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjektPoprawkowy.Models;

namespace ProjektPoprawkowy.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjektPoprawkowy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjektPoprawkowy.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            const string USER_ROLE = "user";
            const string ADMIN_ROLE = "admin";
            const string ADMIN_LOGIN = "admin@com.pl";
            const string ADMIN_PSWD = "Admin!23";
            const string USER_LOGIN = "user1@wp.pl";
            const string USER_PSWD = "Haslo!23";

            if (!roleManager.RoleExists(ADMIN_ROLE)) roleManager.Create(new IdentityRole(ADMIN_ROLE));
            if (!roleManager.RoleExists(USER_ROLE))roleManager.Create(new IdentityRole(USER_ROLE));

            if (userManager.FindByEmail(ADMIN_LOGIN) == null)
            {
                var user = new ApplicationUser { IsActive = true, UserName = ADMIN_LOGIN, Email = ADMIN_LOGIN };
                var adminResult = userManager.Create(user, ADMIN_PSWD);

                if (adminResult.Succeeded) userManager.AddToRole(user.Id, ADMIN_ROLE);
            }
            if (userManager.FindByEmail(USER_LOGIN) == null)
            {
                var user = new ApplicationUser { IsActive = true, UserName = USER_LOGIN, Email = USER_LOGIN };
                var userResult = userManager.Create(user, USER_PSWD);

                if (userResult.Succeeded) userManager.AddToRole(user.Id, USER_ROLE);
            }
            context.SaveChanges();

            var songs = new List<AudioFile>()
                {
                new AudioFile("Back in black","AC/DC","1980",4,14),
                new AudioFile("Highway to hell","AC/DC","1970",3,57),
                new AudioFile("Shoot to thrill","AC/DC","1989",2,32),
                new AudioFile("TNT","AC/DC","1983",5,34),
                new AudioFile("Rock or bust","AC/DC","2015",4,3),
                new AudioFile("Snow","RHCP","1997",4,25),
                new AudioFile("Callifornication","RHCP","200",4,15),
                new AudioFile("Rocks","Robinsons","1940",3,57),
                new AudioFile("Makes","Acid Drinkres","2015",2,23),
                new AudioFile("Robust","ACers","2005",3,29),
                new AudioFile("Rives","Droves","2007",3,5),
                new AudioFile("Carat","Cabarete","2002",5,15),
                new AudioFile("People","Funk","1950",4,47)
                };
            context.Songs.AddRange(songs);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
