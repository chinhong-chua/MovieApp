using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MovieApp.Models;
using MovieApp.ViewModel;

namespace MovieApp.Controllers
{
    //[AllowAnonymous]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            //var movieList = GetMovies();
            //var movies = _context.Movies.Include(m => m.Genre).ToList();

            //return View(movies);

            if (User.IsInRole(RoleName.CanManageMovies))
                return View();
            return View("ReadOnlyList");

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var genres = _context.Genres.DistinctBy(g => g.Name).ToList();
            //table1.GroupBy(x => x.Text).Select(x => x.FirstOrDefault());

            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var model = new MovieFormViewModel()
                {
                    Genres = _context.Genres.DistinctBy(g => g.Name).ToList()
                };
                return View(model);
            }
            if (movie != null)
            {
                if (movie.Id == 0)
                    movie.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genre,
                Id = id,
                Name = movie.Name,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock

            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(MovieFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var movie = new MovieFormViewModel()
                {
                    Genres = _context.Genres.DistinctBy(g => g.Name).ToList(),
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    GenreId = viewModel.GenreId,
                    ReleaseDate = viewModel.ReleaseDate,
                    NumberInStock = viewModel.NumberInStock
                };
                return View(movie);
            }

            if (viewModel != null)
            {

                var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Id);
                movieInDb.Name = viewModel.Name;
                movieInDb.GenreId = viewModel.GenreId;
                movieInDb.ReleaseDate = viewModel.ReleaseDate;
                movieInDb.NumberInStock = viewModel.NumberInStock;
                movieInDb.DateAdded = DateTime.Now.Date;

                try
                {
                    _context.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }

            return RedirectToAction("Index");
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