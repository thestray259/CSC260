using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameLibrary.Models
{
    public class VideoGame 
    {
        public string Title { get; set; } = "NO TITLE"; 
        public string Platform { get; set; } = "NO PLATFORM"; 
        public string Genre { get; set; } = "NO GENRE"; 
        public string Rating { get; set; } = "NOT RATED";
        public int YearOfRelease { get; set; }
        public string ImageName { get; set; }

        public string LoanedTo { get; set; } = null;
        public DateTime? LoanDate { get; set; } //= null; 

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
