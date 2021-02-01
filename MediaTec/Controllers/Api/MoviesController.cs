using MediaTec.Dtos;
using MediaTec.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

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
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m =>m.Genre)
                .ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            //return movie;
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST //api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // return movie;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/Movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                 throw new HttpResponseException(HttpStatusCode.BadRequest);
              
            var inDBMovie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (inDBMovie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, inDBMovie);
            //inDBMovie.Name = movie.Name;
            //inDBMovie.ReleaseDate = movie.ReleaseDate;
            //inDBMovie.GenreId = movie.GenreId;
            //inDBMovie.NumberInStock = movie.NumberInStock;

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
