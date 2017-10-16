using System.Web.Mvc;

namespace FourWheels.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAds()
        {
            return View();
        }
    }
}