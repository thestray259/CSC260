using InClass.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Interfaces;
using InClass.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InClass.Controllers
{
    [Authorize]
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
            return View(dal.GetMovies(User.FindFirstValue(ClaimTypes.NameIdentifier)).OrderBy(m => m.ReleaseDate).ToList());
        }

        [HttpGet] 
        public IActionResult AddMovie()
        {
            ViewBag.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var genreList = dal.GetGenres();
            ViewBag.Genres = new SelectList(genreList, "Id", "Title"); 

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
            m = dal.GetMovie(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            ViewBag.Mode = "Edit";
            ViewBag.ID = id;

            var genreList = dal.GetGenres();
            ViewBag.Genres = new SelectList(genreList, "Id", "Title");

            return View("MovieForm", m);
        }

        // does the save of the existing record 
        public IActionResult UpdateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                dal.UpdateMovie(User.FindFirstValue(ClaimTypes.NameIdentifier), movie);
                return Redirect("/Movie/Index"); 
            }

            return View("MovieForm", movie); 
        }

        public IActionResult DeleteMovie(int? id)
        {
            dal.RemoveMovie(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            return View("Index", dal.GetMovies(User.FindFirstValue(ClaimTypes.NameIdentifier)));
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
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier); // wacky id 
            string email = User.FindFirstValue(ClaimTypes.Email); // also .Name

            //Movie m = new Movie("Iron Man", 2008, 5.0f); 
            return View("MovieForm");
        }
    }
}
