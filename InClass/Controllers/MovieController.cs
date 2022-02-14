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

        public IActionResult Index()
        {
            //return View(MovieList);
            return View(dal.GetMovies().OrderBy(m => m.ReleaseDate).ToList());
        }

        [HttpGet] 
        public IActionResult AddMovie()
        {
            return View("AddMovie"); 
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                dal.AddMovie(movie); 
                return Redirect("/Movie/Index"); 
            }

            return View("MovieForm", movie); 
        }

        public IActionResult EditMovie(int id)
        {
            Movie m;
            m = dal.GetMovie(id);
            ViewBag.Mode = "Edit";
            ViewBag.ID = id; 

            return View("MovieForm", m);
        }

        // does the save of the existing record 
        public IActionResult UpdateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                dal.UpdateMovie(movie);
                return Redirect("/Movie/Index"); 
            }

            return View("MovieForm", movie); 
        }

        public IActionResult DeleteMovie(int? id)
        {
            dal.RemoveMovie(id);
            return View("Index", dal.GetMovies());
        }

        public IActionResult MovieForm()
        {
            return View();
        }

        public IActionResult Search(string searchTerm)
        {
            return View();
        }

        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Iron Man", 2008, 5.0f); 
            return View(m);
        }
    }
}
