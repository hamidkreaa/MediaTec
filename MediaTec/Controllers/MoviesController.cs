using MediaTec.Models;
using MediaTec.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaTec.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> Movies;


        public MoviesController()
        {
            Movies = new List<Movie> {
                new Movie{Id = 1, Name = "Shrek!"},
                new Movie{Id = 2, Name = "Wall-e"},
            };

        }


        public ActionResult MovieCustomers()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer{Name = "Hamid Kreaa"},
                new Customer{Name = "Farah Kreaa"}
            };

            var viewModel = new MovieCustomersViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            return View(viewModel);
        }
     


        // return Content("Hello Hamid");
        // return HttpNotFound();
        // return new EmptyResult();
        // return RedirectToAction("Index", "Home" , new {page = 1, sortBy = "name"});

        //ViewResult -> View()
        //PatialViewResult -> PartialView()
        //ContentResult -> Content()
        //RedirectResult -> Redirect()
        //RedirecToRoutetResult -> RedirectToAction()
        //JsonResult -> Json()
        //FileResult -> File()
        //HttpNotFoundResult -> HttpNotFound()
        //EmptyResult -> EmptyResult()


        // http://localhost:52273/movies/edit/5
        //http://localhost:52273/movies/edit?id=7
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}): range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // GET: Movies
        //http://localhost:52273/movies?Pageindex=2&sortby=Hamid
        public ActionResult index(int? pageIndex, string sortBy)

        {
            //var movies = new List<Movie> {
            //    new Movie{Id = 1, Name = "Shrek!"},
            //    new Movie{Id = 2, Name = "Wall-e"},
            //};

            return View(Movies);

            //if (!pageIndex.HasValue)
            //    pageIndex = 1;
            //if (string.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";
            //return Content(string.Format("PageIndex={0}&sortBy{1}", pageIndex,sortBy));
        }

        public ActionResult Details(int id)
        {
            var movie = Movies.Find(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}