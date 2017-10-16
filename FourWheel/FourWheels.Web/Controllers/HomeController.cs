using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using FourWheels.Services.Contracts;
using FourWheels.Web.Models.CarViewModels;
using System.Linq;
using System.Web.Mvc;

namespace FourWheels.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarAdServices carAdServices;
        private readonly IMapper mapper;

        public HomeController(ICarAdServices carAdServices, IMapper mapper)
        {
            Guard.WhenArgument(carAdServices, "carAdServices").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.carAdServices = carAdServices;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        //[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult HomeIndex()
        {
            var lastAds = this.carAdServices
              .GetLastFiveAddedAds()
              .ProjectTo<CarAdBasicInfoViewModel>()
              .ToList();

            Guard.WhenArgument(lastAds, "lastAds").IsNull().Throw();

            return this.View(lastAds);
        }
    }
}