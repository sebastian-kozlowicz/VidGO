using System;

namespace Video_Rental_Shop.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Customer Customer { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}