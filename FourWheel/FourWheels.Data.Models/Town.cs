using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;

namespace FourWheels.Data.Models
{
    public class Town : BaseDataModel
    {
        private ICollection<CarAd> carAds;

        public Town()
        {
            this.carAds = new HashSet<CarAd>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthTownName)]
        [MaxLength(DataModelsConstants.MaxLengthTownName)]
        public string Name { get; set; }

        public virtual ICollection<CarAd> CarAds
        {
            get { return this.carAds; }
            set { this.carAds = value; }
        }
    }
}
