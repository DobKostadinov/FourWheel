using FourWheels.Data.Models;
using System.Linq;

namespace FourWheels.Services.Contracts
{
    public interface IUserServices : IService
    {
        User GetUserById(string id);

        IQueryable<CarAd> AllUserAds(string userId);

        void UpdateUserInfo(User user);
    }
}
