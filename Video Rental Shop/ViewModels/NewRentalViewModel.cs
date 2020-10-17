using System.Collections.Generic;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.ViewModels
{
    public class NewRentalViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}