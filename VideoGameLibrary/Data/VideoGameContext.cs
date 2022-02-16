using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models; 

namespace VideoGameLibrary.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions options) : base(options)
        {

        }

        // Will create the VideoGames table in the DB using VideoGames.cs model 
        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
