﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using System.Web.Mvc;

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
        public Membership Membership { get; set; }
        public IList<Rental> Rentals { get; set; }

        private ApplicationDbContext _context;

        public Customer()
        {
            _context = new ApplicationDbContext();
        }

        public Customer SetMembershipDuration(Customer customer)
        {
            var durationInMonthsOfMembership = _context.MembershipTypes.Where(m => m.Id == customer.Membership.MembershipTypeId).Select(m => m.DurationInMonths).SingleOrDefault();
            customer.Membership.AssignDate = DateTime.Now;

            if (customer.Membership.MembershipTypeId == MembershipType.PayAsYouGo)
                customer.Membership.ExpiryDate = null;
            else
                customer.Membership.ExpiryDate = (DateTime.Now).AddMonths(durationInMonthsOfMembership);

            _context.Dispose();

            return customer;
        }
    }
}