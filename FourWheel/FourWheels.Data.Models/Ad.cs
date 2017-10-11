using System;
using System.ComponentModel.DataAnnotations;

using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;

namespace FourWheels.Data.Models
{
    public class Ad : BaseDataModel
    {
        public virtual Car Car { get; set; }

        [Range(
            DataModelsConstants.MinLengthAdTitle,
            DataModelsConstants.MaxLengthAdTitle)]
        public string Title { get; set; }

        [Range(
            DataModelsConstants.MinCarPrice,
            DataModelsConstants.MaxCarPrice)]
        public decimal Price { get; set; }

        public Guid TownId { get; set; }

        public virtual Town Town { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
