using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Rental_Shop.ViewModels;
using Video_Rental_Shop.Models;
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

        public ActionResult New(int id, string assignTo)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var movies = _context.Movies.ToList();
            var games = _context.Games.ToList();
            var genres = _context.Genres.ToList();

            var viewModel = new NewRentalViewModel
            {
                Customer = customer,
                Movies = movies,
                Games = games,
                Genres = genres
            };

            return View(viewModel);
        }

        [Route("Rentals/Save/{customerId}/{Id}/{productType}")]
        [HttpPost]
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

            return Content(productType);
        }

        public ActionResult RentedProducts(int id)
        {
            var customer = _context.Rentals.SingleOrDefault(c => c.CustomerId == id);
            var movie = _context.Rentals.Where(r => r.CustomerId == id).Select(m => m.Movie);


            return View(movie);
        }
    }
}