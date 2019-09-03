using System;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Video_Rental_Shop.Models.Validators;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models
{
    [Validator(typeof(MovieValidator))]
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? NumberInStock { get; set; }
        public int? NumberAvailable { get; set; }
        public decimal? Price { get; set; }
        public MovieGenre MovieGenre { get; set; }
        public byte MovieGenreId { get; set; }
        public IList<Rental> Rentals { get; set; }
        
        /// <summary>
        /// Calculates new available number of movies after editing existing one 
        /// </summary>
        /// <param name="movieInDb">Editing movie in database</param>
        /// <param name="movie">Edited copy of movie from database</param>
        public void SetNewNumberAvailable(Movie movieInDb, Movie movie)
        {
           var NumberInStockDifference = movie.NumberInStock - movieInDb.NumberInStock;
           movieInDb.NumberAvailable = movie.NumberAvailable + NumberInStockDifference;
        }
    }
}