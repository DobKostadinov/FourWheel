using System.Collections.Generic;
using System.Linq;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using Bytes2you.Validation;

namespace FourWheels.Services
{
    public class CarBrandServices : ICarBrandServices
    {
        private readonly IEfRepostory<CarBrand> carBrandsRepo;

        public CarBrandServices(IEfRepostory<CarBrand> carBrandsRepo)
        {
            Guard.WhenArgument(carBrandsRepo, "carBrandsRepo").IsNull().Throw();

            this.carBrandsRepo = carBrandsRepo;
        }

        public IEnumerable<CarBrand> GetAllBrands()
        {
            return this.carBrandsRepo.All.ToList();
        }
    }
}
