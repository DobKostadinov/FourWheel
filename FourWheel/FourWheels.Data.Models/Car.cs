using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;
using FourWheels.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Data.Models
{
    public class Car : BaseDataModel
    {
        private ICollection<CarFeature> carFeatures;

        public Car()
        {
            this.carFeatures = new HashSet<CarFeature>();
        }

        [Range(
            DataModelsConstants.MinManufactureYear, 
            DataModelsConstants.MaxManufactureYear)]
        public int ManufactureYear { get; set; }

        [Range(
            DataModelsConstants.MinCarMileage,
            DataModelsConstants.MaxCarMileage)]
        public int Mileage { get; set; }

        public Guid CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public virtual CarImage CarImage { get; set; }

        public CarType CarType { get; set; }

        public FuelType FuelType { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public virtual Ad Ad { get; set; }
        
        public virtual ICollection<CarFeature> CarFeatures
        {
            get { return this.carFeatures; }
            set { this.carFeatures = value; }
        }
    }
}
