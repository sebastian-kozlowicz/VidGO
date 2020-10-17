using System.Linq;
using System.Web.Mvc;
using Video_Rental_Shop.Models;
using Video_Rental_Shop.ViewModels;
using System.Data.Entity;

namespace Video_Rental_Shop.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.Membership.MembershipType).ToList();

            if (User.IsInRole(RoleName.CanDoAllManipulationsOnEntities))
                return View("List", customers);
            else if (User.IsInRole(RoleName.CanDoManipulationsOnEntitiesExceptDeletion))
                return View("ListWithoutDeletions", customers);

            return View("ReadOnlyList", customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.Membership.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.Membership).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities)]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                customer.SetMembershipDuration(customer);
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Include(c => c.Membership).Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Surname = customer.Surname;
                customerInDb.Email = customer.Email;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.Balance = customer.Balance;

                if (customerInDb.Membership.MembershipTypeId != customer.Membership.MembershipTypeId)
                {
                    customerInDb.Membership.MembershipTypeId = customer.Membership.MembershipTypeId;
                    customerInDb.SetMembershipDuration(customerInDb);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        public ActionResult TopUpBalance(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View("TopUpBalance", customer);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        [Route("Customers/TopUpBalance/{customerId}/{depositAmount:decimal}")]
        public ActionResult TopUpBalance(int customerId, decimal depositAmount)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == customerId);
            customer.Balance += depositAmount;

            _context.SaveChanges();

            return Json(new { result = "Success", balance = customer.Balance });
        }
    }
}