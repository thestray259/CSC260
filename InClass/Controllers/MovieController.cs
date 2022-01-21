using InClass.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClass.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie("Iron Man", 2008, 5.0f),
            new Movie("Blob", 2019, 5.0f),
            new Movie("Man", 2003, 2.1f),
            new Movie("Rando", 1998, 3.8f)
        };

        [HttpGet] 
        public IActionResult AddMovie()
        {
            Movie m = new Movie("Spider-Man", 2002, 4.99f); 

            return View("MovieForm", m);
        }

        public IActionResult MovieForm()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(MovieList);
        }

        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Iron Man", 2008, 5.0f); 
            return View(m);
        }
    }
}
