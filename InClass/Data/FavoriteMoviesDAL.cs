using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Models;
using InClass.Interfaces;

namespace InClass.Data
{
    public class FavoriteMoviesDAL //: IDataAccessLayer
    {
        public static List<Movie> MovieList = new List<Movie>
        {
            new Movie("Cat", 2008, 5.0f),
            new Movie("Blob", 2019, 5.0f),
            new Movie("WoMan", 2003, 4.1f),
            new Movie("Rando", 1998, 4.8f)
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

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
