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
            var movies = _context.Movies.Include(g => g.MovieGenre).ToList();
            var games = _context.Games.Include(g => g.GameGenre).Include(g => g.GamePlatform).ToList();

            var viewModel = new NewRentalViewModel
            {
                Customer = customer,
                Movies = movies,
                Games = games
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
            RentalDetailsViewModel viewModel = null;

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var movies = _context.Rentals.Where(r => r.CustomerId == id).Select(m => m.Movie).Include(m => m.MovieGenre).ToList();
            var games = _context.Rentals.Where(r => r.CustomerId == id).Select(g => g.Game).Include(g => g.GameGenre).ToList();
            var datesRented = _context.Rentals.Where(r => r.CustomerId == id).Select(d => d.DateRented).ToList();
            var datesReturned = _context.Rentals.Where(r => r.CustomerId == id).Select(d => d.DateReturned).ToList();
            var rentalIds = _context.Rentals.Where(r => r.Customer.Id == id).Select(r => r.Id).ToList();

            viewModel = new RentalDetailsViewModel
            {
                RentalIds = rentalIds,
                Customers = customer,
                Movies = movies,
                Games = games,
                DatesRented = datesRented,
                DateReturned = datesReturned
            };

            return View(viewModel);
        }

        [Route("Rentals/ReturnProduct/{rentalId}/{productType}")]
        public ActionResult ReturnProduct(int rentalId, string productType)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == rentalId);
            Movie movie = null;
            Game game = null;

            if (productType == "Movie")
            {
                movie = _context.Movies.SingleOrDefault(m => m.Id == rental.MovieId);
                if (movie == null)
                    return HttpNotFound();

                movie.NumberAvailable++;
            }
            else if (productType == "Game")
            {
                game = _context.Games.SingleOrDefault(m => m.Id == rental.GameId);
                if (game == null)
                    return HttpNotFound();

                game.NumberAvailable++;
            }

            rental.DateReturned = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction("RentedProducts", "Rentals", new { id = rental.CustomerId });
        }
    }
}