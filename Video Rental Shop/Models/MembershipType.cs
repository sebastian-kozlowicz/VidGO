using System.Collections.Generic;

namespace Video_Rental_Shop.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short DurationInMonths { get; set; }
        public byte SignUpFee { get; set; }
        public byte DiscountRate { get; set; }
        public IList<Membership> Memberships { get; set; }

        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Annual = 4;
    }
}