using FourWheels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Services.Contracts
{
    public interface ICarBrandServices : IService
    {
        IEnumerable<CarBrand> GetAllBrands();
    }
}
