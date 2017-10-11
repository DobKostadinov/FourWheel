using FourWheels.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Data.Models
{
    public class CarImage : IIdentifiable
    {
        public CarImage()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public byte[] Image { get; set; }

        public virtual Car Car { get; set; }
    }
}
