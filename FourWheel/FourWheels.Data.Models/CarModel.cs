using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;

namespace FourWheels.Data.Models
{
    public class CarModel : BaseDataModel
    {
        private ICollection<CarAd> cars;

        public CarModel()
        {
            this.cars = new HashSet<CarAd>();
        }

        [Required]
        [MinLength(DataModelsConstants.MinLengthCarModel)]
        [MaxLength(DataModelsConstants.MaxLengthCarModel)]
        public string Model { get; set; }

        public Guid CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }

        public virtual ICollection<CarAd> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
