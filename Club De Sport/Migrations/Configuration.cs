namespace Club_De_Sport.Migrations
{
    using Club_De_Sport.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<Club_De_Sport.Models.ClubDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Club_De_Sport.Models.ClubDbContext context)
        {
            context.Users.AddOrUpdate(u => new { u.Email, u.Role },
                new User
                {
                    Email = "Admin@mail.com",
                    Password = Crypto.HashPassword("Admin123"),
                    Role = User.Admin

                });
            var coachs = context.Coaches.ToList();
            var activities = context.Activites.Include(a => a.Coachs).ToList();
            foreach (var activity in activities)
            {
                activity.Coachs = coachs;
            }
            context.SaveChanges();

        }
    }
}
