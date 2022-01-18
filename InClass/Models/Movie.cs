using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClass.Models
{
    public class Movie
    {
        public string Title { get; set; } = "NO TITLE";
        public int Year { get; set; } = 1850;
        public float Rating { get; set; } = 0.0f;

        public Movie() { }

        public Movie(string title, int year, float rating)
        {
            this.Title = title;
            this.Year = year;
            this.Rating = rating; 
        }

        public override string ToString()
        {
            return $"{Title} - {Year} - {Rating} stars";
        }
    }
}
