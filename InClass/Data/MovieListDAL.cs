using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Models;
using InClass.Interfaces; 

namespace InClass.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        public static List<Movie> MovieList = new List<Movie>
        {
            new Movie("Iron Man", 2008, 5.0f),
            new Movie("Blob", 2019, 5.0f),
            new Movie("Man", 2003, 2.1f),
            new Movie("Rando", 1998, 3.8f)
        };

        public void AddMovie(Movie movie)
        {
            MovieList.Add(movie); 
        }

        public Movie GetMovie(int? id)
        {
            Movie foundMovie = null; 

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
            return foundMovie; 
        }

        public IEnumerable<Movie> GetMovies()
        {
            return MovieList; 
        }

        public void RemoveMovie(int? id)
        {
            var foundMovie = GetMovie(id); 
            if (foundMovie != null)
            {
                MovieList.Remove(foundMovie); 
            }
        }

        public IEnumerable<Movie> Search(string searchTerm)
        {
            //string.IsNullOrEmpty(strTitle) // check to make sure there's something there
            List<Movie> tmpMovies = new List<Movie>(); 

            foreach (var g in MovieList)
            {
                if (g.Title.ToUpper().Contains(searchTerm.ToUpper())) //if contains the the searchterm, add to the list and return the list // ToUpper makes all the chars uppercase 
                {
                    tmpMovies.Add(g); 
                }
            }

            return tmpMovies;

            // these are the doing the same thing as the above code 
            //return MovieList.Where(g => g.Title.ToUpper().Contains(searchTerm.ToUpper())).ToList(); 
            //return MovieList.Contains(g => g.Title.ToUpper().Contains(searchTerm.ToUpper())).ToList(); 
            //return MovieList.FindAll(g => g.Title.ToUpper().Contains(searchTerm.ToUpper())).ToList(); 
        }
    }
}
