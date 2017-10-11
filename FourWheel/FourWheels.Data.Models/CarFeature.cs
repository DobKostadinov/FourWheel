using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FourWheels.Data.Models.Contracts;
using FourWheels.Common;

namespace FourWheels.Data.Models
{
    public class CarFeature : IIdentifiable
    {
        private ICollection<Car> cars;

        public CarFeature()
        {
            this.Id = Guid.NewGuid();
            this.cars = new HashSet<Car>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthCarFeature)]
        [MaxLength(DataModelsConstants.MaxLengthCarFeature)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
