using InClass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InClass.Controllers
{
    public class HomeController : Controller
    {
        private static int count = 0; 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Form()
        {
            ViewBag.count = count++; 
            return View();
        }

        [HttpPost] // makes it so that you can only submit data via post, not get 
        public IActionResult Result(string FirstName)
        {
            //ViewBag.FirstName = Request.Form["FirstName"]; 
            ViewBag.FirstName = FirstName; 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
