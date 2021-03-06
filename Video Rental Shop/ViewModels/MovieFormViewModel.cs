﻿using System.Collections.Generic;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> Genres { get; set; }
        public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}