using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class HomeController : Controller
    {
        public static DateTime dateTime = DateTime.Now; 
        private static List<VideoGame> GameList = new List<VideoGame>
        {
            new VideoGame("Genshin Impact", "PC", "Adventure Role-Playing", "T", 2020, "genshin.jfif"), 
            new VideoGame("Kingdom Hearts", "PlayStation2", "Action Role-Playing", "E10+", 2002, "kingdom_hearts.jpg"), 
            new VideoGame("Assassin's Creed: Brotherhood", "PlayStation4", "Action Adventure, Stealth", "M", 2010, "ac_brotherhood.jpg"), 
            new VideoGame("Dead By Daylight", "PC", "Action, Survival-Horror", "M", 2016, "dbd.jpg", "Jeff", dateTime), 
            new VideoGame("The Legend of Spyro: Dawn of the Dragon", "Wii", "Fantasy, Action-Adventure", "E10+", 2008, "spyro.jpg") 
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(GameList);
        }

        [HttpPost]
        public IActionResult ReturnGame(string title)
        {
            var game = GameList.Find(x => x.Title == title);
            game.ReturnGame(); 
            return View("Privacy", GameList);
        }

        [HttpPost]
        public IActionResult LoanGame(string title, string loaner)
        {
            var game = GameList.Find(x => x.Title == title);
            game.Loan(loaner);
            return View("Privacy", GameList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
