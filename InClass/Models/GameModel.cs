using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClass.Models
{
    public class GameModel : Controller
    {
        public string Title { get; set; } = "NO TITLE";
        public int Year { get; set; } = 1850;
        public bool RentedOut = false; 

        public GameModel() { }

        public GameModel(string title, int year, bool rentedOut)
        {
            this.Title = title;
            this.Year = year;
            this.RentedOut = rentedOut; 
        }

        public override string ToString()
        {
            return $"{Title} - {Year} - Rented Out: {RentedOut}"; 
        }
    }
}
