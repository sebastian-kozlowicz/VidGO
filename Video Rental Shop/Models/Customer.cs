using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Attributes;
using Video_Rental_Shop.Models.Validators;


namespace Video_Rental_Shop.Models
{
    [Validator(typeof(CustomerValidator))]
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public DateTime? Birthdate { get; set; }
        public Membership Membership { get; set; }
        public IList<Rental> Rentals { get; set; }

        private ApplicationDbContext _context;

        public Customer()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Sets AssignDate of membership to current date
        /// If customer's membership type is PayAsYouGo ExpiryDate is set to null
        /// Otwerwise add to current date number of months of membership duration and assign a result to ExpiryDate
        /// </summary>
        /// <param name="customer">Customer object</param>
        public void SetMembershipDuration(Customer customer)
        {
            var durationInMonthsOfMembership = _context.MembershipTypes.Where(m => m.Id == customer.Membership.MembershipTypeId).Select(m => m.DurationInMonths).SingleOrDefault();
            customer.Membership.AssignDate = DateTime.Now;

            if (customer.Membership.MembershipTypeId == MembershipType.PayAsYouGo)
                customer.Membership.ExpiryDate = null;
            else
                customer.Membership.ExpiryDate = (DateTime.Now).AddMonths(durationInMonthsOfMembership);

            _context.Dispose();
        }
    }
}