namespace CinemaWorld.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using CinemaWorld.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Countries.Any())
            {
                context.Countries.AddOrUpdate(
                    new Country { Name = "USA" },
                    new Country { Name = "France" },
                    new Country { Name = "Italy" },
                    new Country { Name = "Russia" },
                    new Country { Name = "German" },
                    new Country { Name = "Bulgaria" });

                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                context.Cities.AddOrUpdate(
                    new City { Name = "Sofia", CountryId = 6 },
                    new City { Name = "Pleven", CountryId = 6 },
                    new City { Name = "Ruse", CountryId = 6 },
                    new City { Name = "Varna", CountryId = 6 },
                    new City { Name = "Burgas", CountryId = 6 },
                    new City { Name = "Plovdiv", CountryId = 6 });

                context.SaveChanges();
            }

            if (!context.Genres.Any())
            {
                context.Genres.AddOrUpdate(
                    new Genre { Name = "Action" },
                    new Genre { Name = "Animation" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Horror" },
                    new Genre { Name = "Thriller" },
                    new Genre { Name = "Fantasy" });

                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(
                    new Category { Name = "A" },
                    new Category { Name = "B" },
                    new Category { Name = "C" },
                    new Category { Name = "D" });

                context.SaveChanges();

            }

            if (!context.Roles.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var roleResult = roleManager.Create(new IdentityRole("Admin"));

                var user = new ApplicationUser() { UserName = "Admin" };
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var result = userManager.Create(user, "adminpass");
                userManager.AddToRole(user.Id, "Admin");

                context.SaveChanges();
            }

            if (!context.Cinemas.Any())
            {
                context.Cinemas.AddOrUpdate(
                    new Cinema { Name = "Cinema City", CityId = 1 },
                    new Cinema { Name = "Cine Grand", CityId = 1 },
                    new Cinema { Name = "Arena Zapad", CityId = 1 },
                    new Cinema { Name = "Cinema Mladost", CityId = 1 });

                context.SaveChanges();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddOrUpdate(
                    new Movie { Title = "Fury", Description = "April, 1945. As the Allies make their final push in the European Theatre, a battle-hardened army sergeant named Wardaddy commands a Sherman tank and his five-man crew on a deadly mission behind enemy lines. Out-numbered, out-gunned, and with a rookie soldier thrust into their platoon, Wardaddy and his men face overwhelming odds in their heroic attempts to strike at the heart of Nazi Germany.", Year = 2014, Duration = 135, Director = "David Ayer", ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMjA4MDU0NTUyN15BMl5BanBnXkFtZTgwMzQxMzY4MjE@._V1_SX214_AL_.jpg", CountryId = 1, CategoryId = 2 },
                    new Movie { Title = "The Maze Runner", Description = "Thomas is deposited in a community of boys after his memory is erased, soon learning they're all trapped in a maze that will require him to join forces with fellow runners for a shot at escape.", Year = 2014, Duration = 113, Director = "Wes Ball", ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMjUyNTA3MTAyM15BMl5BanBnXkFtZTgwOTEyMTkyMjE@._V1_SX214_AL_.jpg", CountryId = 1, CategoryId = 2 });
            }

            if (!context.News.Any())
            {
                context.News.AddOrUpdate(
                    new News { Content = "Oscar winner Jared Leto is circling a key role in David Ayer�s �Suicide Squad� that could prove to be The Joker, an individual familiar with the Warner Bros. project has told TheWrap. Warner Bros. had no comment, while a representative for Leto did not immediately respond to a request for comment. Tom Hardy, Will Smith and Margot Robbie are in various stages of discussions to star in �Suicide Squad,� which David Ayer is directing and Charles Roven is producing. Jesse Eisenberg is also expected to reprise his role as Superman's mortal foe Lex Luthor, though no casting is confirmed at this time.", CreatedOn = DateTime.Now },
                    new News { Content = "Amanda Bynes needed a change, so she made a big one. The former child star revealed that she opted to add more color to her usual blond tresses, and switched up her 'do with a purple hue! Bynes stepped out with her new lavender locks today, debuting the finished look after letting her Twitter followers know earlier in the day that she was at the hair salon for a dye job. I dyed my hair violet :D I'm not sure if I like it , and this is a blurry pic but here it is ! We like it! Although the change in color is an interesting move, what seems more puzzling is the fact that Bynes just said she didnt have enough money for a hotel, but apparently had enough dollars for a pricey ", CreatedOn = DateTime.Now },
                    new News { Content = "Here's yet another reason why Tig Notaro is a woman who can't help but blaze a trail of inspiration (and laughter, of course) wherever she goes. As detailed on The New Yorker's website today, the comedian�who broke through in a big way when she revealed during a stand-up set in 2012 that she had breast cancer and proceeded to bring the house down�responded to a catcall-type whoop from an audience member at her show in NYC last night by ripping open her shirt, scars from a double mastectomy fully visible, and continuing to perform topless for 20 minutes. Performing at The Town Hall, a stop on her Boyish Girl Interrupted Tour, Notaro was telling a bit about getting a pat-down at the airport and ", CreatedOn = DateTime.Now });
            }

        }
    }
}