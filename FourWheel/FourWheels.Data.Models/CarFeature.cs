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
        [MinLength(1)]
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
