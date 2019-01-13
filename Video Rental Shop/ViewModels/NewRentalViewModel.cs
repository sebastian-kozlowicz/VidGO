using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.ViewModels
{
    public class NewRentalViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}