using MadForInputs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MadForInputs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy(string noun1, string noun2, string noun3, string noun4, 
                                     string adj1, string adj2, string adj3, string adj4,
                                     string adj5, string adj6, string verb1, string verb2,
                                     string verb3, string verb4)
        {
            ViewBag.noun1 = noun1;
            ViewBag.noun2 = noun2;
            ViewBag.noun3 = noun3;
            ViewBag.noun4 = noun4;
            ViewBag.adj1 = adj1;
            ViewBag.adj2 = adj2;
            ViewBag.adj3 = adj3;
            ViewBag.adj4 = adj4;
            ViewBag.adj5 = adj5;
            ViewBag.adj6 = adj6;
            ViewBag.verb1 = verb1;
            ViewBag.verb2 = verb2;
            ViewBag.verb3 = verb3;
            ViewBag.verb4 = verb4;
            return View();                         
        }                                           
                                                    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()                
        {                                           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }                                          
    }                                              
}                                                  
                                                   