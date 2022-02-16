using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameLibrary.Models
{
    public class VideoGame 
    {
        [Required] [Column(TypeName = "varchar(50)")]
        public string Title { get; set; } 
        [Required] [Column(TypeName = "varchar(15)")]
        public string Platform { get; set; } 
        [Required] [Column(TypeName = "varchar(100)")]
        public string Genre { get; set; } 
        [Required] [Column(TypeName = "varchar(10)")]
        public string Rating { get; set; } 
        [Required]
        public int YearOfRelease { get; set; }
        [Required] [Column(TypeName = "varchar(75)")]
        public string ImageName { get; set; } = "no_image.jpg";

        [Column(TypeName = "varchar(20)")]
        public string LoanedTo { get; set; } = null;
        public DateTime? LoanDate { get; set; } 

        [Required]
        public int ID { get; set; }

        public VideoGame() { }

        public VideoGame(string title, string platform, string genre, string rating, int year, string image, string loanedTo, DateTime loanDate)
        {
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.Rating = rating;
            this.YearOfRelease = year;
            this.ImageName = image; 
            this.LoanedTo = loanedTo;
            this.LoanDate = loanDate; 
        }

        public VideoGame(string title, string platform, string genre, string rating, int year, string image)
        {
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.Rating = rating;
            this.YearOfRelease = year;
            this.ImageName = image; 
        }

        public void Loan(string loanedTo)
        {
            this.LoanedTo = loanedTo;
            LoanDate = DateTime.Now; 
        }

        public void ReturnGame()
        {
            LoanedTo = null;
            LoanDate = null; 
        }
    }
}
