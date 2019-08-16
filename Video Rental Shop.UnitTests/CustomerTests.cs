using System;
using NUnit.Framework;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.UnitTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer customer;
        private const byte PayAsYouGo = 1;
        private const byte Monthly = 2;
        private const byte Quarterly = 3;
        private const byte Annual = 4;

        [SetUp]
        public void SetUp()
        {
            customer = new Customer
            {
                Membership = new Membership()
            };
        }

        [Test]
        [TestCase(Monthly, 1)]
        [TestCase(Quarterly, 4)]
        [TestCase(Annual, 12)]
        public void SetMembershipDuration_WhenCalledByNonPayAsYouGoCustomerMembership_AssignValueForAssignDateAndExpiryDate(byte membershipType, int durationInMonthsOfMembership)
        {
            customer.Membership.MembershipTypeId = membershipType;

            customer.SetMembershipDuration(customer);

            Assert.That(customer.Membership.AssignDate.Value.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.That(customer.Membership.ExpiryDate.Value.ToShortDateString(), Is.EqualTo(DateTime.Now.AddMonths(durationInMonthsOfMembership).ToShortDateString()));
        }

        public void SetMembershipDuration_WhenCalledByPayAsYouGoCustomerMembership_AssignValueForAssignDateAndExpiryDate()
        {
            customer.Membership.MembershipTypeId = PayAsYouGo;

            customer.SetMembershipDuration(customer);

            Assert.That(customer.Membership.AssignDate.Value.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.That(customer.Membership.ExpiryDate, Is.EqualTo(null));
        }
    }
}
