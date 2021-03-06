﻿using MediaTec.Models;
using MediaTec.ViewModels;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;

namespace MediaTec.Controllers
{
    public class MoviesController : Controller
    {
        //public List<Movie> Movies;
        private ApplicationDbContext _context;


        public MoviesController()
        {
            //Movies = new List<Movie> {
            //    new Movie{Id = 1, Name = "Shrek!"},
            //    new Movie{Id = 2, Name = "Wall-e"},
            //};

            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {             
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        //Save Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {                   
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            { 
                movie.AddDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);

                // TryUpdateModel(customerInDB);
                //Mapper.Map(customer, customerInDB);

                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
               
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}): range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // GET: Movies
        //http://localhost:52273/movies?Pageindex=2&sortby=Hamid
        public ViewResult index(int? pageIndex, string sortBy)

        {
            //var movies = new List<Movie> {
            //    new Movie{Id = 1, Name = "Shrek!"},
            //    new Movie{Id = 2, Name = "Wall-e"},
            //};
            //var movies = _context.Movies.Include(m=>m.Genre).ToList();
            //return View(movies);

            //if (!pageIndex.HasValue)
            //    pageIndex = 1;
            //if (string.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";
            //return Content(string.Format("PageIndex={0}&sortBy{1}", pageIndex,sortBy));

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            //  var movie = Movies.Find(x => x.Id == id);
            var movie = _context.Movies.Include(m => m.Genre).Where(m => m.Id == id).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}