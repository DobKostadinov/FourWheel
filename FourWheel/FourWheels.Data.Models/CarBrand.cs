using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;

namespace FourWheels.Data.Models
{
    public class CarBrand : BaseDataModel
    {
        private ICollection<CarModel> models;

        public CarBrand()
        {
            this.models = new HashSet<CarModel>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthCarBrand)]
        [MaxLength(DataModelsConstants.MaxLengthCarBrand)]
        public string Brand { get; set; }

        public virtual ICollection<CarModel> CarModels
        {
            get { return this.models; }
            set { this.models = value; }
        }
    }
}
