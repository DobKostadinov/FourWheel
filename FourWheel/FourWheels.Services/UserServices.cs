using Bytes2you.Validation;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Data.UnitOfWork;
using FourWheels.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Services
{
    public class UserServices : IUserServices
    {
        private readonly IEfRepostory<User> usersRepo;
        private readonly ICarAdServices carAdServices;
        private readonly IEfUnitOfWork unitOfWork;

        public UserServices(IEfRepostory<User> usersRepo, ICarAdServices carAdServices, IEfUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(carAdServices, "carAdServices").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.usersRepo = usersRepo;
            this.carAdServices = carAdServices;
            this.unitOfWork = unitOfWork;
        }

        public User GetUserById(string id)
        {
            return this.usersRepo.All.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<CarAd> AllUserAds(string userId)
        {
            return this.carAdServices.GetAll().Where(x => x.UserId == userId);
        }

        public void UpdateUserInfo(User user)
        {
            this.usersRepo.Update(user);
            this.unitOfWork.Commit();
        }
    }
}
