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
        public ActionResult BrowseCarAds()
        {
            var allAds = this.carAdServices.GetAll();

            var model = allAds.Select(x => new CarAdViewModel
            {
                Brand = x.CarModel.CarBrand.Brand,
                Model = x.CarModel.Model,
                Town = x.Town.Name
            });

            return this.View(model);
        }


        [HttpGet]
        public ActionResult AddAd()
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

            this.ViewBag.CarBrandsDropdown = carBrandsDropdown;


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

            this.ViewBag.TownsDropDown = townsDropDown.OrderBy(x => x.Text);

            var allFeatures = this.carFeatureServices
                .GetAllCarFeatures()
                .ProjectTo<CarFeatureViewModel>()
                .ToList();

            var model = new CarAdInputModel
            {
                CarFeatures = allFeatures
            };

            return this.View(model);
        }

        [HttpPost]
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

            return Json(carModelsDropdown.OrderBy(x => x.Text), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAd(CarAdInputModel model)
        {
            var userId = User.Identity.GetUserId();
            var carModelIdGuid = Guid.Parse(model.CarModelId);
            var townIdGuid = Guid.Parse(model.TownId);

            var selectedCarFeaturesIds = model
                .CarFeatures
                .Where(x => x.IsChecked == true)
                .Select(x => x.Id);

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



            //var userId = User.Identity.GetUserId();
            //var newCar = new Car();
            //newCar = this.mapper.Map(model, newCar);
            //newCar.UserId = userId;

            //this.carServices.AddNewCar(newCar);

            return RedirectToAction("BrowseCarAds", "CarAd");
        }
    }
}