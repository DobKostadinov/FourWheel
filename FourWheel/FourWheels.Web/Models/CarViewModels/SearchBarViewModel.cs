using FourWheels.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourWheels.Web.Models.CarViewModels
{
    public class SearchBarViewModel
    {
        public ICollection<SelectListItem> CarBrandsDropDown { get; set; }

        public ICollection<SelectListItem> TownsDropDown { get; set; }

        public CarType CarType { get; set; }

        public FuelType Year { get; set; }

        public int ManufactureYear { get; set; }
    }
}