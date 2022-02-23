using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Models;
using InClass.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InClass.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        /*        public static List<Movie> MovieList = new List<Movie>
                {
                    new Movie("Iron Man", 2008, 5.0f),
                    new Movie("Blob", 2019, 5.0f),
                    new Movie("Man", 2003, 2.1f),
                    new Movie("Rando", 1998, 3.8f)
                };*/

        private MovieContext db; 

        public MovieListDAL(MovieContext indb)
        {
            this.db = indb; 
        }

        public void AddMovie(Movie movie)
        {
            movie.ID = 0; // Might need this, might not 
            db.Add(movie);
            db.SaveChanges(); 
            //MovieList.Remove(movie); 
            //MovieList.Add(movie); 
        }

        public List<Genre> GetGenres()
        {
            throw new NotImplementedException();
            //return db.Genres.ToList(); 
        }

        public Movie GetMovie(string userId, int? id)
        {
            return db.Movies
                .Where(m => m.ID == id && m.UserID == userId).Include(m => m.genre)
                .FirstOrDefault(); 

            //return db.Movies.FirstOrDefault(m => m.ID == id); 

/*            Movie foundMovie = null; 

            if (id != null)
            {
                MovieList.ForEach(m =>
                {
                    if (m.ID == id)
                    {
                        foundMovie = m;
                    }
                });
            }
            return foundMovie; */
        }

        public IEnumerable<Movie> GetMovies(string userId)
        {
            return db.Movies.Where(m => m.UserID == userId).ToList();
        }

        public void RemoveMovie(string userId, int? id)
        {
            Movie foundMovie = GetMovie(userId, id); 
            if (foundMovie != null)
            {
                db.Movies.Remove(foundMovie);
                db.SaveChanges(); 
            }

/*            var foundMovie = GetMovie(id); 
            if (foundMovie != null)
            {
                MovieList.Remove(foundMovie); 
            }*/
        }

        public void UpdateMovie(string userId, Movie movie)
        {
            movie.UserID = userId; 
            db.Update(movie);
            db.SaveChanges();
        }

        /*        public IEnumerable<Movie> Search(string searchTerm)
                {
                    //string.IsNullOrEmpty(strTitle) // check to make sure there's something there
                    List<Movie> tmpMovies = new List<Movie>(); 

        *//*            foreach (var g in MovieList)
                    {
                        if (g.Title.ToUpper().Contains(searchTerm.ToUpper())) //if contains the the searchterm, add to the list and return the list // ToUpper makes all the chars uppercase 
                        {
                            tmpMovies.Add(g); 
                        }
                    }*//*

                    return tmpMovies;
                }*/
    }
}
