using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new MvcMovieContext(
            //serviceProvider.GetRequiredService<
            //DbContextOptions<MvcMovieContext>>()))

            //string[] args = { "serviceProvider.GetRequiredService()" };
            string[] args = { "" };
            using (MvcMovieContext context = new DesignTimeContextFactory().CreateDbContext(args))    
            {
                // Look for any movies. If there are any movies
                // in the database, the seed initializer returns
                // and no movies are added.
                if (context.MovieModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.MovieModel.AddRange(
                    new MovieModel
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Price = 7.99M
                    },

                    new MovieModel
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Rating = "R",
                        Genre = "Comedy",
                        Price = 8.99M
                    },

                    new MovieModel
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Rating = "R",
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new MovieModel
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Rating = "R",
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
