using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models
{
    public class GameGenre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public IList<Game> Games { get; set; }
    }
}