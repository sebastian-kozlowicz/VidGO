using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
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
        public GameGenre GameGenre { get; set; }
        public byte GameGenreId { get; set; }
        public GamePlatform GamePlatform { get; set; }
        public byte GamePlatformId { get; set; }
    }
}