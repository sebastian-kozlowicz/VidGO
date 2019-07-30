using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;

namespace Video_Rental_Shop.Models
{
    [Validator(typeof(CustomerValidator))]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public DateTime? Birthdate { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public IList<Rental> Rentals { get; set; }
    }
}