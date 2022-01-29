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
        private static List<VideoGame> GameList = new List<VideoGame>
        {
            new VideoGame("Genshin Impact", "PC", "Adventure Role-Playing", "T", 2020), 
            new VideoGame("Kingdom Hearts", "PlayStation2", "Action Role-Playing", "E10+", 2002), 
            new VideoGame("Assassin's Creed Brotherhood", "PlayStation4", "Action Adventure, Stealth", "M", 2010), 
            new VideoGame("Placeholder", "Placeholder", "Placeholder", "Placeholder", 0000, "Jeff", DateTime.Now), 
            new VideoGame("Placeholder", "Placeholder", "Placeholder", "Placeholder", 0000)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
