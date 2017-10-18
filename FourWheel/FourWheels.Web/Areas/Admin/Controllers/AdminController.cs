using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using FourWheels.Services.Contracts;
using FourWheels.Web.Areas.Admin.Models;
using System.Linq;
using System.Web.Mvc;

namespace FourWheels.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserServices userServices;
        private readonly IMapper mapper;

        public AdminController(IUserServices userServices, IMapper mapper)
        {
            Guard.WhenArgument(userServices, "userServices").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.userServices = userServices;
            this.mapper = mapper;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUsers()
        {
            var model = this.userServices
                .GetAllUsers()
                .ProjectTo<UsersDetailsViewModel>()
                .ToList();

            return this.View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(string id)
        {
            this.userServices.DeleteUser(id);
            return this.RedirectToAction("DeleteUsers");
        }
    }
}