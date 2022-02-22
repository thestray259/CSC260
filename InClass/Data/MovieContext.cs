using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Models; 

namespace InClass.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options)
        {

        }

        // Will create the Movies table in the DB using Movie.cs model 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie> Genres { get; set; }
    }
}
