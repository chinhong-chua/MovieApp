using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieApp.Models;
using MovieApp.ViewModel;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using AutoMapper;
using MovieApp.Dtos;

namespace MovieApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        // GET api/<controller>
        public IEnumerable<MovieDto> GetMovies()
        {
            //return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            //return _context.Movies.ToList();
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }
        [HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            //if (movie == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            if (movie == null) return NotFound();

            //return movie;
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        // Create api/<controller>
        public IHttpActionResult Create(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            //throw new HttpResponseException((HttpStatusCode.BadRequest));

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
            //movie.DateAdded=DateTime.Now.Date;
            //_context.Movies.Add(movie);
            //_context.SaveChanges();
        }

        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult Edit(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();
            //throw new HttpResponseException(HttpStatusCode.NotFound);

            //movieInDb.DateAdded = movie.DateAdded;
            //movieInDb.GenreId = movie.GenreId;
            //movieInDb.Name = movie.Name;
            //movieInDb.ReleaseDate = movie.ReleaseDate;
            //movieInDb.NumberInStock = movie.NumberInStock;

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();

        }
    }
}