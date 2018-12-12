using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Video_Rental_Shop.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short DurationInMonths { get; set; }
        public byte SingUpFee { get; set; }
        public byte DiscountRate { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}