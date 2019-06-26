using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models
{
    [Validator(typeof(MovieValidation))]
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? NumberInStock { get; set; }
        public int? NumberAvailable { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public MovieGenre MovieGenre { get; set; }
        public byte MovieGenreId { get; set; }
        public IList<Rental> Rentals { get; set; }
    }
}