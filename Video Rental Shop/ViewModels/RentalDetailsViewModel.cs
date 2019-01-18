using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.ViewModels
{
    public class RentalDetailsViewModel
    {
        public IEnumerable<int> RentalIds { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<GameGenre> Genres { get; set; }
        public IEnumerable<DateTime> DatesRented { get; set; }
        public IEnumerable<DateTime?> DateReturned { get; set; }
    }
}