using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClass.Models
{
    public class MoviePage
    {
        public MoviePage() { }

        public MoviePage(IEnumerable<Movie> movieList, SelectList genreList)
        {
            this.MovieList = movieList;
            this.Genres = genreList;
        }

        public IEnumerable<Movie> MovieList { get; set; }
        public SelectList Genres { get; set;}
    }
}
