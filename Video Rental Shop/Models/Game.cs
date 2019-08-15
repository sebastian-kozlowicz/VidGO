using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models
{
    [Validator(typeof(GameValidation))]
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? NumberInStock { get; set; }
        public int? NumberAvailable { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public GameGenre GameGenre { get; set; }
        public byte GameGenreId { get; set; }
        public GamePlatform GamePlatform { get; set; }
        public byte GamePlatformId { get; set; }
        public IList<Rental> Rentals { get; set; }

        /// <summary>
        /// Calculates new available number of games after editing existing one
        /// </summary>
        /// <param name="gameInDb">Editing game in database</param>
        /// <param name="game">Edited copy of game from database</param>
        /// <returns></returns>
        public void SetNewNumberAvailable(Game gameInDb, Game game)
        {
            var NumberInStockDifference = game.NumberInStock - gameInDb.NumberInStock;
            gameInDb.NumberAvailable = game.NumberAvailable + NumberInStockDifference;
        }
    }
}