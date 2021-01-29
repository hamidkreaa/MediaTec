using MediaTec.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediaTec.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m =>m.Genre).ToList();
        }

        // GET /api/Movies/1
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return movie;
        }

        // POST //api/Movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        // PUT /api/Movies/1
        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var inDBMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (inDBMovie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            inDBMovie.Name = movie.Name;
            inDBMovie.ReleaseDate = movie.ReleaseDate;
            inDBMovie.GenreId = movie.GenreId;
            inDBMovie.NumberInStock = movie.NumberInStock;

            _context.SaveChanges();
        }

        // PUT /api/Movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var inDBMovie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (inDBMovie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(inDBMovie);
            _context.SaveChanges();            
        }
    }
}
