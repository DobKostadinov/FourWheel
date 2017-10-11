using FourWheels.Common;
using FourWheels.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Data.Models
{
    public class CarModel : IIdentifiable
    {

        private ICollection<Car> cars;

        public CarModel()
        {
            this.Id = Guid.NewGuid();
            this.cars = new HashSet<Car>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthCarModel)]
        [MaxLength(DataModelsConstants.MaxLengthCarModel)]
        public string Model { get; set; }

        public Guid CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
