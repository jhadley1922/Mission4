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

        public DbSet<MovieList> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieList>().HasData(
                new MovieList
                {
                    MovieID = 1,
                    Title = "The Avengers",
                    Category = "Action/Adventure",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false,
                    Notes = ""
                },
                new MovieList
                {
                    MovieID = 2,
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    Category = "Action/Adventure",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                    Notes = ""
                },
                new MovieList
                {
                    MovieID = 3,
                    Title = "Hitch",
                    Category = "Comedy",
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
