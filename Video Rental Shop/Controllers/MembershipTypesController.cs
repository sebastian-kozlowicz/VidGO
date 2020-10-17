using System.Linq;
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
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var membershipTypes = _context.MembershipTypes.Include(m => m.Memberships).ToList();

            return View(membershipTypes);
        }

        [Authorize(Roles = RoleName.CanDoAllManipulationsOnEntities + "," + RoleName.CanDoManipulationsOnEntitiesExceptDeletion)]
        [Route("MembershipTypes/GetMembershipTypeSignUpFee/{membershipTypeId}")]
        public ActionResult GetMembershipTypeSignUpFee(int membershipTypeId)
        {
            var signUpFee = _context.MembershipTypes.Where(m => m.Id == membershipTypeId).Select(m => m.SignUpFee).FirstOrDefault();

            return Json(new { result = "Success", signUpFee });
        }
    }
}