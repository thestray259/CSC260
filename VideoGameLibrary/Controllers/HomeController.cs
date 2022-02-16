using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;
using VideoGameLibrary.Data; 

namespace VideoGameLibrary.Controllers
{
    public class HomeController : Controller
    {
        IDataAccessLayer dal;

        public HomeController(IDataAccessLayer indal) 
        {
            dal = indal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(dal.GetCollection()); 
        }

        [HttpPost]
        public IActionResult ReturnGame(string title)
        {
            dal.ReturnGame(title); 
            return View("Privacy", dal.GetCollection());
        }

        [HttpPost]
        public IActionResult LoanGame(string title, string loaner)
        {
            dal.LoanGame(title, loaner); 
            return View("Privacy", dal.GetCollection());
        }

        [HttpPost]
        public IActionResult AddGame(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                dal.AddGame(game);
                return Redirect("/Home/Privacy"); 
            }

            return Content("AddGame was called but ModelState is NOT valid."); 
        }

        [HttpPost]
        public IActionResult DeleteGame(int? id)
        {
            dal.DeleteGame(id);
            return View("Privacy", dal.GetCollection()); 
        }

        [HttpPost]
        public IActionResult SearchGame(string searchTerm) 
        {
            return View("Privacy", dal.SearchForGames(searchTerm)); 
        }

        [HttpPost]
        public IActionResult FilterGames(string genre, string platform, string esrbRating)
        {
            return View("Privacy", dal.FilterCollection(genre, platform, esrbRating)); 
        }

        public IActionResult EditGame(int id)
        {
            VideoGame m;
            m = dal.GetGame(id);
            ViewBag.Mode = "Edit";
            ViewBag.ID = id;

            return View("EditGames", m);
        }

        public IActionResult UpdateGame(VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                dal.UpdateGame(videoGame);
                return Redirect("/Home/Privacy");
            }

            return View("EditGames", videoGame); 
        }

        public IActionResult EditGames()
        {
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
