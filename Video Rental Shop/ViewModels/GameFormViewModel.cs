using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<GameGenre> Genres { get; set; }
        public IEnumerable<GamePlatform> Platforms { get; set; }
        public Game Game { get; set; }

        public string Title
        {
            get
            {
                if (Game != null && Game.Id != 0)
                    return "Edit Game";

                return "New Game";
            }
        }
    }
}