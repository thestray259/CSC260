using InClass.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Interfaces;
using InClass.Data; 

namespace InClass.Controllers
{
    public class MovieController : Controller
    {
        //IDataAccessLayer dal = new MovieListDAL(); //bad because of hard coding 
        IDataAccessLayer dal; 

        public MovieController(IDataAccessLayer indal) // needed for assignment 
        {
            dal = indal; 
        }

        [HttpGet] 
        public IActionResult AddMovie()
        {
            //Movie m = new Movie("Spider-Man", 2002, 4.99f); 
            //return View("MovieForm", m);
            return View("AddMovie"); 
        }

        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //MovieList.Add(movie);
                dal.RemoveMovie(movie.ID); 
                dal.AddMovie(movie); 
                return Redirect("/Movie/Index"); 
            }

            return View("MovieForm", movie); 
        }

        public IActionResult MovieForm()
        {
            return View();
        }

        public IActionResult Search(string searchTerm)
        {
            return View();
        }

        public IActionResult EditMovie(int id)
        {
            Movie m;
            m = dal.GetMovie(id);
            dal.RemoveMovie(id); 

            return View("MovieForm", m);
        }

        public IActionResult DeleteMovie(int? id)
        {
            dal.RemoveMovie(id); 
            return View("Index", dal.GetMovies());
        }

        public IActionResult Index()
        {
            //return View(MovieList);
            return View(dal.GetMovies().OrderBy(m => m.ReleaseDate).ToList()); 
        }

        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Iron Man", 2008, 5.0f); 
            return View(m);
        }
    }
}
