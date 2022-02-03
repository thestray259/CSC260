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
