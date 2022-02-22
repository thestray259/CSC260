using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Models; 

namespace InClass.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Movie> GetMovies(string userId);
        void AddMovie(Movie movie);
        void RemoveMovie(string userId, int? id);
        Movie GetMovie(string userId, int? id);
        void UpdateMovie(string userId, Movie movie);
        public List<Genre> GetGenres(); 
    }
}
