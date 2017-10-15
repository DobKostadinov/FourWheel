using FourWheels.Common;
using FourWheels.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FourWheels.Web.Models.CarViewModels
{
    public class SearchBarInputViewModel
    {
        public string CarBrandId { get; set; }

        public string CarModelId { get; set; }

        public CarType CarType { get; set; }

        public FuelType FuelType { get; set; }

        [Display(Name = "Manufacture year")]
        [Range(DataModelsConstants.MinManufactureYear,
            DataModelsConstants.MaxManufactureYear,
            ErrorMessage = ErrorMessages.RangeShouldBeBetween)]
        public int ManufactureYear { get; set; }
    }
}