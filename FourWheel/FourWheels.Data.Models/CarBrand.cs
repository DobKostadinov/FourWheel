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
    public class CarBrand : IIdentifiable
    {
        private ICollection<CarModel> models;

        public CarBrand()
        {
            this.Id = Guid.NewGuid();
            this.models = new HashSet<CarModel>();
        }

        [Key]
        public Guid Id { get; set; }

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
