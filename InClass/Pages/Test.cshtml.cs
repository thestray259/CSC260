using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Data;
using InClass.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InClass.Pages
{
    public class TestModel : PageModel
    {
        MovieContext _movieContext; 

        public Movie movie { get; set; }

        public TestModel(MovieContext context)
        {
            this._movieContext = context; 
        }

        public IActionResult OnGet()
        {
            return Page(); 
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
            return Page(); 
        }
    }
}
