﻿using System;

namespace Video_Rental_Shop.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public int? MovieId { get; set; }
        public Game Game { get; set; }
        public int? GameId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}