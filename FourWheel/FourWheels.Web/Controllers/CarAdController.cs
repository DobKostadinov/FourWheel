using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Web.Models.CarViewModels;
using FourWheels.Services.Contracts;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using Bytes2you.Validation;
using System;
using FourWheels.Web.Models.UserViewModels;

namespace FourWheels.Web.Controllers
{
    public class CarAdController : Controller
    {
        private readonly ICarAdServices carAdServices;
        private readonly ICarBrandServices brandServices;
        private readonly ICarModelServices carModelServices;
        private readonly ICarFeatureServices carFeatureServices;
        private readonly ITownServices townServices;

        private readonly IMapper mapper;

        public CarAdController(
            ICarAdServices carAdServices,
            ICarBrandServices brandServices,
            ICarModelServices carModelServices,
            ICarFeatureServices carFeatureServices,
            ITownServices townServices,
            IMapper mapper)
        {
            Guard.WhenArgument(carAdServices, "carAdServices").IsNull().Throw();
            Guard.WhenArgument(brandServices, "brandServices").IsNull().Throw();
            Guard.WhenArgument(carModelServices, "carModelServices").IsNull().Throw();
            Guard.WhenArgument(carFeatureServices, "carFeatureServices").IsNull().Throw();
            Guard.WhenArgument(townServices, "townServices").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();

            this.carAdServices = carAdServices;
            this.brandServices = brandServices;
            this.carModelServices = carModelServices;
            this.carFeatureServices = carFeatureServices;
            this.townServices = townServices;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult BrowseCarAds()
        {
            var ads = this.carAdServices
               .GetAll()
               .ProjectTo<CarAdBasicInfoViewModel>()
               .ToList();

            Guard.WhenArgument(ads, "ads").IsNull().Throw();


            return this.View(ads);
        }

        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult LoadSearchBar()
        {
            this.ViewBag.CarBrandsDropdown = this.GetAllBrandsAsDropDown();
            this.ViewBag.TownsDropDown = this.GetAllTownsAsDropDown();

            return this.PartialView("_SearchBarPartial");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SearchBarResult(SearchBarInputViewModel searchInputModel)
        {
            var adsDb = this.carAdServices.GetAll();

            if (searchInputModel != null)
            {
                if (!string.IsNullOrEmpty(searchInputModel.CarBrandId))
                {
                    var carBrandIdAsGuid = Guid.Parse(searchInputModel.CarBrandId);
                    adsDb = adsDb.Where(x => x.CarModel.CarBrand.Id == carBrandIdAsGuid);
                }

                if (!string.IsNullOrEmpty(searchInputModel.CarModelId))
                {
                    var carModelIdAsGuid = Guid.Parse(searchInputModel.CarModelId);
                    adsDb = adsDb.Where(x => x.CarModel.Id == carModelIdAsGuid);
                }


                if (searchInputModel.CarType != 0)
                {
                    adsDb = adsDb.Where(x => x.CarType == searchInputModel.CarType);
                }

                if (searchInputModel.FuelType != 0)
                {
                    adsDb = adsDb.Where(x => x.FuelType == searchInputModel.FuelType);
                }

                if (searchInputModel.FuelType != 0)
                {
                    adsDb = adsDb.Where(x => x.FuelType == searchInputModel.FuelType);
                }

                if (searchInputModel.ManufactureYear != 0)
                {
                    adsDb = adsDb.Where(x => x.ManufactureYear == searchInputModel.ManufactureYear);
                }

                var ads = adsDb
                    .ProjectTo<CarAdBasicInfoViewModel>()
                    .ToList();

                return this.View("BrowseCarAds", ads);
            }
  
            else
            {
                return this.RedirectToAction("BrowseCarAds");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult LoadAdFullDetails(Guid id)
        {
            var specifiedAd = this.carAdServices.GetAdById(id);

            Guard.WhenArgument(specifiedAd, "specifiedAd").IsNull().Throw();

            var user = specifiedAd.User;

            var adFullView = this.mapper.Map<CarAdFullInfoViewModel>(specifiedAd);
            var userInfo = this.mapper.Map<UserDetailsViewModel>(user);

            var model = new CarAdFullDetailsViewModel
            {
                AdInfo = adFullView,
                UserDetails = userInfo
            };

            return this.View(model);
        }

        



        [HttpGet]
        [Authorize]
        public ActionResult AddAd()
        {        
            this.ViewBag.CarBrandsDropdown = this.GetAllBrandsAsDropDown();
            this.ViewBag.TownsDropDown = this.GetAllTownsAsDropDown();

            var allFeatures = this.carFeatureServices
                .GetAllCarFeatures()
                .ProjectTo<CarFeatureInputViewModel>()
                .ToList();

            Guard.WhenArgument(allFeatures, "allFeatures").IsNull().Throw();

            var model = new CarAdInputModel
            {
                CarFeatures = allFeatures
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetModelsByBrand(string id)
        {
            var brandIdAsGuid = Guid.Parse(id);

            ICollection<SelectListItem> carModelsDropdown = new List<SelectListItem>();
            IEnumerable<CarModel> carModelsByBrandFromDb = this.carModelServices.GetAllModelsByBrand(brandIdAsGuid);

            Guard.WhenArgument(carModelsByBrandFromDb, "carModelsByBrandFromDb").IsNull().Throw();

            foreach (var model in carModelsByBrandFromDb)
            {
                carModelsDropdown.Add(new SelectListItem
                {
                    Text = model.Model,
                    Value = model.Id.ToString()
                });
            }

            return this.Json(carModelsDropdown.OrderBy(x => x.Text), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddAd(CarAdInputModel model)
        {
            var userId = User.Identity.GetUserId();
            var carModelIdGuid = Guid.Parse(model.CarModelId);
            var townIdGuid = Guid.Parse(model.TownId);

            var selectedCarFeaturesIds = model
                .CarFeatures
                .Where(x => x.IsChecked == true)
                .Select(x => x.Id);

            Guard.WhenArgument(selectedCarFeaturesIds, "selectedCarFeaturesIds").IsNull().Throw();

            this.carAdServices.AddNewCarAd(
                model.Title,
                carModelIdGuid,
                model.CarType,
                model.ManufactureYear, 
                model.Mileage,
                model.FuelType, 
                model.TransmissionType,
                selectedCarFeaturesIds,
                townIdGuid,
                model.Price,
                model.AdditionalInfo,
                model.CarImageUrl, 
                userId);

            return this.RedirectToAction("BrowseCarAds", "CarAd");
        }

        [HttpGet]
        [Authorize]
        public ActionResult DeleteCarAd(string id)
        {
            var adIdAsGuid = Guid.Parse(id);

            this.carAdServices.DeleteAd(adIdAsGuid);

            return this.RedirectToAction("UserAds", "Account");
        }

        [ChildActionOnly]
        private ICollection<SelectListItem> GetAllBrandsAsDropDown()
        {
            ICollection<SelectListItem> carBrandsDropdown = new List<SelectListItem>();
            IEnumerable<CarBrand> carBrandsFromDb = this.brandServices.GetAllBrands();

            Guard.WhenArgument(carBrandsFromDb, "carBrandsFromDb").IsNull().Throw();

            foreach (var brand in carBrandsFromDb)
            {
                carBrandsDropdown.Add(new SelectListItem
                {
                    Text = brand.Brand,
                    Value = brand.Id.ToString()
                });
            }

            carBrandsDropdown.OrderBy(x => x.Text);

            return carBrandsDropdown;
        }

        [ChildActionOnly]
        public ICollection<SelectListItem> GetAllTownsAsDropDown()
        {
            ICollection<SelectListItem> townsDropDown = new List<SelectListItem>();
            IEnumerable<Town> townsFromDb = this.townServices.GetAllTowns();

            Guard.WhenArgument(townsFromDb, "townsFromDb").IsNull().Throw();

            foreach (var town in townsFromDb)
            {
                townsDropDown.Add(new SelectListItem
                {
                    Text = town.Name,
                    Value = town.Id.ToString()
                });
            }

            townsDropDown.OrderBy(x => x.Text);

            return townsDropDown;
        }
    }
}