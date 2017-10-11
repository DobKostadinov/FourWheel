using FourWheels.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Data.Models
{
    public class Ad : BaseDataModel
    {
        public virtual Car Car { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public Guid TownId { get; set; }

        public virtual Town Town { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
