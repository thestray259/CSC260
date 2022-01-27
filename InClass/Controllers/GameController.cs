using InClass.Models; 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClass.Controllers
{
    public class GameController : Controller
    {
        private static List<GameModel> MovieList = new List<GameModel>
        {
            new GameModel("Iron Man", 2008, false),
            new GameModel("Blob", 2019, true),
            new GameModel("Man", 2003, true),
            new GameModel("Rando", 1998, false),
            new GameModel("Bam", 2014, false),
            new GameModel("Pop", 2012, true)
        };

        public IActionResult Game()
        {
            return View(MovieList);
        }

        public IActionResult RentMovie()
        {
            return View();
        }
    }
}
