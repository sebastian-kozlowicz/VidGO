using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Video_Rental_Shop.Models;

namespace Video_Rental_Shop.Controllers
{
    public class MembershipTypesController : Controller
    {
        private ApplicationDbContext _context;

        public MembershipTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var membershipTypes = _context.MembershipTypes.Include(m => m.Customers).ToList();

            return View(membershipTypes);
        }
    }
}