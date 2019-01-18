using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> Genres { get; set; }
        public Movie Game { get; set; }

        public string Title
        {
            get
            {
                if (Game != null && Game.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}