using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data
{
    public class MoviesDatabase : DbContext
    {
        public MoviesDatabase (DbContextOptions<MoviesDatabase> options)
            : base(options)
        {
        }

        public DbSet<Movies.Models.Movie> Movie { get; set; }

        public DbSet<Movies.Models.Cinema> Cinema { get; set; }

        public DbSet<Movies.Models.Kids_Collection> Kids_Collection { get; set; }

        public DbSet<Movies.Models.Show> Show { get; set; }
    }
}
