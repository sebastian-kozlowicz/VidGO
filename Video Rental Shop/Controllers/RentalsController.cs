using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Rental_Shop.ViewModels;
using Video_Rental_Shop.Models;
using System.Data.Entity;
using System.Net;

namespace Video_Rental_Shop.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var movies = _context.Movies.ToList();
            var games = _context.Games.ToList();
            var movieGenres = _context.MovieGenres.ToList();

            var viewModel = new RentalViewModel
            {
                Customer = customer,
                Movies = movies,
                Games = games,
                MovieGenres = movieGenres
            };

            return View(viewModel);
        }

        [Route("Rentals/Save/{customerId}/{Id}/{productType}")]
        public ActionResult Save(int customerId, int Id, string productType)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == customerId);

            Rental rental = null;
            Movie movie = null;
            Game game = null;

            if (productType == "Movie")
            {
                movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

                rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                movie.NumberAvailable--;
            }
            else if (productType == "Game")
            {
                game = _context.Games.SingleOrDefault(m => m.Id == Id);

                rental = new Rental
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now
                };

                game.NumberAvailable--;
                _context.Rentals.Add(rental);
            }

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            return RedirectToAction("RentedProducts", "Rentals", new { id = customerId });
        }

        public ActionResult RentedProducts(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var movies = _context.Rentals.Include(m => m.Movie.MovieGenre).Where(c => c.CustomerId == id).Select(m => m.Movie).ToList();
            var games = _context.Rentals.Where(c => c.CustomerId == id).Select(g => g.Game).ToList();
            var genres = _context.MovieGenres.ToList();
            var datesRented = _context.Rentals.Where(c => c.CustomerId == id).Select(d => d.DateRented).ToList();
            var datesReturned = _context.Rentals.Where(c => c.CustomerId == id).Select(d => d.DateReturned).ToList();
            var rentalIds = _context.Rentals.Where(r => r.Customer.Id == id).Select(r => r.Id).ToList();

            var viewModel = new RentalDetailsViewModel
            {
                RentalIds = rentalIds,
                Customer = customer,
                Movies = movies,
                Games = games,
                DatesRented = datesRented,
                DateReturned = datesReturned
            };

            List<RentalDetailsViewModel> list = new List<RentalDetailsViewModel>();
            list.Add(viewModel);

            return View(viewModel);
        }
    }
}