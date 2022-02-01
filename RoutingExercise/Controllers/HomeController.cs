using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoutingExercise.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

/*        public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Index(int? id, string? name)
        {
            if (id == null && name == null) return View();
            if (id != null && name == null) return Content("The cow Default Cow moos at you " + id + " times.");
            if (id != null && name != null) return Content("The cow " + name + " moos at you " + id + " times."); 

            return View(); 
        }

        public IActionResult Index2(int id)
        {
/*            for (int i = 0; i < id; i++)
            {
                return Content("Here's some information on cow " + (i + 1) + ".");  
            }*/
/*            int i = 0; 
            do
            {
                return Content("Here's some information on cow " + (i + 1) + ".");
                i++; 
            } while (i < id); */

            return Content("Error");
        }

        [Route("EatMoreChicken")]
        public IActionResult Chicken()
        {
            return Redirect("https://www.chick-fil-a.com/");
        }

        public IActionResult Privacy()
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
