using System;
using System.ComponentModel.DataAnnotations;

using FourWheels.Data.Models.Contracts;

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
