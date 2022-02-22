using InClass.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InClass.Models
{
    //[NinetysMovieRating]
    public class Movie
    {
        //public static int nextId = 0;

        //private int id = nextId++; 
        [Required]
        public int ID { get; set; }

        [Required] [MaxLength(450)]
        public string UserID { get; set; }

        //[Required(ErrorMessage = "Hey Dummy, the Title is Required")]
        [Column(TypeName = "varchar(500)")]
        public string Title { get; set; } //= "NO TITLE";
        //[Range(1850, 2022, ErrorMessage ="Year must be between 1850 and 2022")]
        public int Year { get; set; } //= 1850;
        //[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public float Rating { get; set; } //= 0.0f;
        public DateTime ReleaseDate; 

        public int GenreId { get; set; }
        public Genre genre { get; set; }

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
