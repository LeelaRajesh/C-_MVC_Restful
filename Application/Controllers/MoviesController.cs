using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

using MVCappli_rest.Models;
using MVCappli_rest.View_Models;

namespace MVCappli_rest.Controllers
{
    public class MoviesController : Controller
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
        // GET: Movies
        public ActionResult Random()
        {

 //           var teststring = "testing the string into file";
            var customers = new List<Customer>
            {
                new Customer {Id=1, Name="Rajesh"},
                new Customer {Id=2, Name="Yamini"},
            };
            var mov = new List<Movies>
            {
                new Movies{Name="The dark Knight"},
                new Movies{Name="The Iron Man"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = mov,
            };
            return View(viewModel);
 //           return File(Encoding.UTF8.GetBytes(teststring),"text/plain","rajeshtest.txt");
        }


        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("MoviesList");
            else
                return View("ReadOnlyMoviesList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int Id)
        {
            var Mov = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);
            return View(Mov);
        }

        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genre = _context.Genres.ToList()
            };
            return View("MoviesForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create(Movies viewModel)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel(viewModel)
                {
                    Genre = _context.Genres.ToList()
                };
                return View("MoviesForm", viewmodel);
            }
            if(viewModel.Id == 0)
            {
                viewModel.NumberAvailable = viewModel.NumberInStock;
                _context.Movies.Add(viewModel);
            }
                
            else
            {
                var MovieInDB = _context.Movies.Single(m => m.Id == viewModel.Id);
                MovieInDB.Name = viewModel.Name;
                MovieInDB.ReleaseDate = viewModel.ReleaseDate;
                MovieInDB.DateAdded = viewModel.DateAdded;
                MovieInDB.GenreId = viewModel.GenreId;
                MovieInDB.NumberInStock = viewModel.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int Id)
        {
            var movie= _context.Movies.SingleOrDefault(m => m.Id==Id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
            };
            return View("MoviesForm",viewModel);
        }

    }
}