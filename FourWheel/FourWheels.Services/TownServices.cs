using Bytes2you.Validation;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Services
{
    public class TownServices : ITownServices
    {
        private readonly IEfRepostory<Town> townsRepo;

        public TownServices(IEfRepostory<Town> townsRepo)
        {
            Guard.WhenArgument(townsRepo, "townsRepo").IsNull().Throw();

            this.townsRepo = townsRepo;
        }

        public IEnumerable<Town> GetAllTowns()
        {
            return this.townsRepo.All.ToList();
        }
    }
}
