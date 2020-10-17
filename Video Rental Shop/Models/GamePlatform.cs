using System.Collections.Generic;

namespace Video_Rental_Shop.Models
{
    public class GamePlatform
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public IList<Game> Games { get; set; }
    }
}