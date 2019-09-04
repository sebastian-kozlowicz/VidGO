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

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult New(int id)
        {
            var customer = _context.Customers.Include(c => c.Membership.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer.Membership.ExpiryDate < DateTime.Now)
            {
                customer.Membership.MembershipTypeId = MembershipType.PayAsYouGo;
                customer.SetMembershipDuration(customer);
            }

            var movies = _context.Movies.Include(g => g.MovieGenre).ToList();
            var games = _context.Games.Include(g => g.GameGenre).Include(g => g.GamePlatform).ToList();

            var viewModel = new NewRentalViewModel
            {
                Customer = customer,
                Movies = movies,
                Games = games
            };

            _context.SaveChanges();

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        [Route("Rentals/Save/{customerId}/{Id}/{productType}")]
        public ActionResult Save(int customerId, int Id, string productType)
        {
            var customer = _context.Customers.Include(m => m.Membership.MembershipType).SingleOrDefault(c => c.Id == customerId);

            Rental rental = null;
            Movie movie = null;
            Game game = null;

            if (productType == "Movie")
            {
                movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
                var moviePrice = movie.Price;
                if (customer.Membership.MembershipType.DiscountRate != 0)
                    moviePrice -= moviePrice * ((decimal)customer.Membership.MembershipType.DiscountRate / 100);

                rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                movie.NumberAvailable--;
                customer.Balance -= (decimal)moviePrice;
            }
            else if (productType == "Game")
            {
                game = _context.Games.SingleOrDefault(m => m.Id == Id);
                var gamePrice = game.Price;
                if (customer.Membership.MembershipType.DiscountRate != 0)
                    gamePrice -= gamePrice * ((decimal)customer.Membership.MembershipType.DiscountRate / 100);

                rental = new Rental
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now
                };

                game.NumberAvailable--;
                customer.Balance -= (decimal)gamePrice;
            }

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            return Json(new { result = "Redirect", url = Url.Action("RentedProducts", "Rentals", new { id = customerId }) });
        }

        public ActionResult RentedProducts(int id)
        {
            var rentals = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .Include(r => r.Movie.MovieGenre)
                .Include(r => r.Game)
                .Include(r => r.Game.GameGenre)
                .Where(c => c.CustomerId == id)
                .ToList();

            return View(rentals);
        }

        public ActionResult AllRentedProducts()
        {
            var rentals = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .Include(r => r.Movie.MovieGenre)
                .Include(r => r.Game)
                .Include(r => r.Game.GameGenre)
                .ToList();

            return View(rentals);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        [Route("Rentals/ReturnProduct/{rentalId}/{productType}/{redirectTo}")]
        public ActionResult ReturnProduct(int rentalId, string productType, string redirectTo)
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

            if (redirectTo == "RentedProducts")
                return RedirectToAction("RentedProducts", "Rentals", new { id = rental.CustomerId });

            return RedirectToAction("AllRentedProducts", "Rentals");
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        [Route("Rentals/TopUpBalance/{customerId}/{depositAmount:decimal}")]
        public ActionResult TopUpBalance(int customerId, decimal depositAmount)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == customerId);
            customer.Balance += depositAmount;

            _context.SaveChanges();

            return Json(new { result = "Success", balance = customer.Balance });
        }
    }
}