using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Rental_Shop.Models;
using System.Data.Entity;
using Video_Rental_Shop.ViewModels;

namespace Video_Rental_Shop.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var games = _context.Games.Include(g => g.GameGenre).Include(g => g.GamePlatform).ToList();

            if (User.IsInRole(RoleName.CanDoAllManipulationsOnEntities))
                return View("List", games);
            else if (User.IsInRole(RoleName.CanDoManipulationsOnEntitiesExceptDeletion))
                return View("ListWithoutDeletions", games);

            return View("ReadOnlyList", games);
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(g => g.GameGenre).Include(g => g.GamePlatform).SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult New()
        {
            var genres = _context.GameGenres.ToList();
            var platforms = _context.GamePlatforms.ToList();

            var viewModel = new GameFormViewModel
            {
                Game = new Game(),
                Genres = genres,
                Platforms = platforms
            };

            return View("GameForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            var genres = _context.GameGenres.ToList();
            var platforms = _context.GamePlatforms.ToList();

            var viewModel = new GameFormViewModel
            {
                Game = game,
                Genres = genres,
                Platforms = platforms
            };

            return View("GameForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities)]
        public ActionResult Delete(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            _context.Games.Remove(game);
            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel
                {
                    Game = new Game(),
                    Genres = _context.GameGenres.ToList(),
                    Platforms = _context.GamePlatforms.ToList()
                };

                return View("GameForm", viewModel);
            }

            if (game.Id == 0)
            {
                game.NumberAvailable = game.NumberInStock;
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);
                gameInDb.SetNewNumberAvailable(gameInDb, game);
                gameInDb.Name = game.Name;
                gameInDb.ReleaseDate = game.ReleaseDate;
                gameInDb.NumberInStock = game.NumberInStock;
                gameInDb.GameGenreId = game.GameGenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }
    }
}