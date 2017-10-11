using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;

namespace FourWheels.Data.Models
{
    public class Town : BaseDataModel
    {
        private ICollection<Ad> ads;

        public Town()
        {
            this.ads = new HashSet<Ad>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(DataModelsConstants.MinLengthTownName)]
        [MaxLength(DataModelsConstants.MaxLengthTownName)]
        public string Name { get; set; }

        public virtual ICollection<Ad> Ads
        {
            get { return this.ads; }
            set { this.ads = value; }
        }
    }
}
