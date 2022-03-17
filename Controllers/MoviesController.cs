using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModel;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movieList = GetMovies();

            return View(movieList);
        }

        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Cruz"
            };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 1"},

            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //ViewBag.Movie = movie;
            return View(viewModel);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
        {
            new Movie(){Id = 1, Name = "Spiderman"},
            new Movie (){Id = 1, Name = "Kingsman"},

        };
        }

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseYear(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}
    }
}