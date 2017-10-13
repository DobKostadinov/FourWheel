using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;

namespace FourWheels.Data.Models
{
    public class CarFeature : BaseDataModel
    {
        private ICollection<CarAd> cars;

        public CarFeature()
        {
            this.cars = new HashSet<CarAd>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthCarFeature)]
        [MaxLength(DataModelsConstants.MaxLengthCarFeature)]
        public string Name { get; set; }

        public virtual ICollection<CarAd> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
