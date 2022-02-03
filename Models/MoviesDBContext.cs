using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "VHS"
                }
            );

            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieID = 1,
                    Title = "The Avengers",
                    CategoryID = 1,
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false,
                    Notes = ""
                },
                new Movie
                {
                    MovieID = 2,
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    CategoryID = 1,
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                    Notes = ""
                },
                new Movie
                {
                    MovieID = 3,
                    Title = "Hitch",
                    CategoryID = 2,
                    Year = 2012,
                    Director = "Andy Tennant",
                    Rating = "PG-13",
                    Edited = false,
                    Notes = ""
                }
            );
        }
    }
}
