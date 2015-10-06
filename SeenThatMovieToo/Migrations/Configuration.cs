namespace MvcApplication1.Migrations
{
    using MvcApplication1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication1.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcApplication1.Models.MovieDBContext context)
        {
            context.Movies.AddOrUpdate(i => i.Title,
                 new Movie
                 {
                     Title = "When Harry Met Sally",
                     WatchedDate = DateTime.Parse("1989-1-11"),
                     Genre = "Romantic Comedy",
                     Rating = 5,
                     userId = "1",
                 },

                  new Movie
                  {
                      Title = "Ghostbusters ",
                      WatchedDate = DateTime.Parse("1984-3-13"),
                      Genre = "Comedy",
                      Rating = 7,
                      userId = "1",
                  },

                  new Movie
                  {
                      Title = "Ghostbusters 2",
                      WatchedDate = DateTime.Parse("1986-2-23"),
                      Genre = "Comedy",
                      Rating = 6,
                      userId = "1",
                  },

                new Movie
                {
                    Title = "Rio Bravo",
                    WatchedDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = 9,
                    userId = "1",
                }
            );
        }
    }
}
