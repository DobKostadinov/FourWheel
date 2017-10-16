using System;
using System.Collections.Generic;
using System.Linq;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;

using Bytes2you.Validation;

namespace FourWheels.Services
{
    public class CarModelServices : ICarModelServices
    {
        private readonly IEfRepostory<CarModel> carModelsRepo;

        public CarModelServices(IEfRepostory<CarModel> carModelsRepo)
        {
            Guard.WhenArgument(carModelsRepo, "carModelsRepo").IsNull().Throw();

            this.carModelsRepo = carModelsRepo;
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            return this.carModelsRepo.All.ToList();
        }

        public IEnumerable<CarModel> GetAllModelsByBrand(Guid id)
        {
            return this.carModelsRepo.All.Where(x => x.CarBrandId == id);
        }
    }
}
