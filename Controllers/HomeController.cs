using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBContext mcContext { get; set; }

        public HomeController(MoviesDBContext name)
        {
            mcContext = name;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = mcContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movie ml)
        {
            if (ModelState.IsValid)
            {
                mcContext.Add(ml);
                mcContext.SaveChanges();

                return View("Confirmation");
            }
            else // if invalid
            {
                ViewBag.Categories = mcContext.Categories.ToList();

                return View();
            }
        }

        [HttpGet]
        public IActionResult Collection()
        {
            var movies = mcContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = mcContext.Categories.ToList();

            var movie = mcContext.Movies.Single(x => x.MovieID == movieid);

            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                mcContext.Update(m);
                mcContext.SaveChanges();

                return RedirectToAction("Collection");
            }
            else // if invalid
            {
                ViewBag.Categories = mcContext.Categories.ToList();

                return View("Movies", m);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = mcContext.Movies.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie m)
        {
            mcContext.Movies.Remove(m);
            mcContext.SaveChanges();

            return RedirectToAction("Collection");
        }
    }
}
