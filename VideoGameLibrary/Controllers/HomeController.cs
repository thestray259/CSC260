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
        IDataAccessLayer dal = new MockVideoGameDB();

/*        public HomeController(IDataAccessLayer indal) // needed for assignment 
        {
            dal = indal;
        }*/

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
/*            var game = GameList.Find(x => x.Title == title);
            game.ReturnGame();
            return View("Privacy", GameList);*/
            
            return View();
        }

        [HttpPost]
        public IActionResult LoanGame(string title, string loaner)
        {
/*            var game = GameList.Find(x => x.Title == title);
            game.Loan(loaner);
            return View("Privacy", GameList);*/

            return View();
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

        public IActionResult DeleteGame(int? id)
        {
            dal.DeleteGame(id);
            return View("Privacy", dal.GetCollection()); 

            //return Content("DeleteGame was called.");
        }

        public IActionResult SearchGame(string searchTerm)
        {
            dal.SearchForGames(searchTerm);
            return View("Privacy", dal.GetCollection()); //probably wrong

            //return Content("SearchGame was called.");
        }

        public IActionResult FilterGames(string genre, string platform, string rating)
        {
            dal.FilterCollection(genre, platform, rating); 
            return View("Privacy", dal.GetCollection()); //probably wrong

            //return Content("FilterGames was called.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
